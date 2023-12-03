using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Extensions;
using MOROPO.VIDERHE.Cloud.Options;
using MOROPO.VIDERHE.Cloud.Persistence.ORM.EF;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class ImagesController : Controller
    {
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;
        private readonly ApplicationDbContext dbContext;
        private readonly Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;

        public ImagesController(IEntityRepository<Image, System.Guid> imageRepository, IImageFileManagerFacade imageFileManager, IThumbnailFileManagerFacade thumbnailFileManager, ApplicationDbContext dbContext, Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions)
        {
            this.imageFileManager = imageFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
            this.dbContext = dbContext;
            this.mediaThumbnailResizeOptions = mediaThumbnailResizeOptions;
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        [HttpGet("page/{page}")]
        [HttpGet("page/{page}/limit/{limit}")]
        public ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<ImageDisplayModel>> GetPage(int page = 1, int limit = 15)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.Include(e => e.ImageBridges).ThenInclude(b => b.Stern).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var maxCount = account.ImageBridges.Count;

            var rest = maxCount % limit;

            var maxPageCount = maxCount / limit;

            if (rest > 0) maxPageCount += 1;

            if (page < 0 || page > maxPageCount)
            {
                page = 1;
            }

            return Ok(new Framework.Guama.Core.Presentation.Models.PaginationModel<ImageDisplayModel>
            {
                List = account.ImageBridges.Select(bridge => bridge.Stern).OrderByDescending(e => e.CreateAt).Skip((page - 1) * limit).Take(limit).Select(entity =>
                {
                    var model = new ImageDisplayModel();

                    model.Import(entity);

                    return model;
                }).ToList(),
                Limit = limit,
                Page = page,
                HasPrevious = page > 1,
                HasNext = page < maxPageCount,
                MaxPageCount = maxPageCount
            });
        }

        [HttpPost]
        public ActionResult Add(Microsoft.AspNetCore.Http.IFormFile file, [FromForm] string about)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.First(e => e.Id == accountId);

            if (file == null)
            {
                file = Request.Form.Files.First();
            }

            using (var imageSkData = SkiaSharp.SKData.Create(file.OpenReadStream(), file.Length))
            {
                using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                {
                    var image = new Image
                    {
                        ContentType = file.ContentType,
                        Length = file.Length,
                        Width = imageSkBitmap.Width,
                        Height = imageSkBitmap.Height,
                        About = about
                    };

                    imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                    SkiaSharp.SKImageInfo desiredImageInfo;

                    if (imageSkBitmap.Width > imageSkBitmap.Height)
                    {
                        desiredImageInfo = imageSkBitmap.Info.LandscapeScale(mediaThumbnailResizeOptions.Value.DesiredWidth);
                    }
                    else
                    {
                        desiredImageInfo = imageSkBitmap.Info.PortraitScale(mediaThumbnailResizeOptions.Value.DesiredHeigth);
                    }

                    using (var thumbnailSkBitmap = imageSkBitmap.Resize(desiredImageInfo, SkiaSharp.SKFilterQuality.High))
                    {
                        using (var thumbnailSkImage = SkiaSharp.SKImage.FromBitmap(thumbnailSkBitmap))
                        {
                            var thumbnailSkData = thumbnailSkImage.Encode(SkiaSharp.SKEncodedImageFormat.Png, 75);

                            image.Thumbnail = new Thumbnail
                            {
                                ContentType = "image/png",
                                Length = thumbnailSkData.Size,
                                About = string.Format(string.Format("Thumbnail: {0}", about))
                            };

                            thumbnailFileManager.SaveThumbnailFileContent(image.Thumbnail.Id, thumbnailSkData.ToArray(), image.Thumbnail.ContentType);
                        }
                    }

                    dbContext.Images.Add(image);

                    dbContext.AccountImageBridges.Add(new Persistence.Entities.AccountImageBridge
                    {
                        ProwId = accountId,
                        SternId = image.Id
                    });

                    dbContext.SaveChanges(User.Identity.Name);
                }
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Edit([FromBody] ImageInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

                    var account = dbContext.Accounts.Include(e => e.ImageBridges).ThenInclude(b => b.Stern).First(e => e.Id == accountId);

                    var entity = account.ImageBridges.First(b => b.SternId == inputModel.Id).Stern;

                    inputModel.Mergue(entity);

                    imageRepository.Update(entity, User.Identity.Name);

                    return Ok();
                }
                catch (System.InvalidOperationException)
                {
                    return NoContent();
                }
                catch (System.Exception)
                {
                    return Conflict();
                }
            }

            return BadRequest();
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(System.Guid key)
        {
            if (dbContext.PlacardImageBridges.Any(item => item.SternId == key))
            {
                return Conflict();
            }

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.Include(e => e.ImageBridges).ThenInclude(b => b.Stern).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var bridge = account.ImageBridges.First(b => b.SternId == key);

            dbContext.AccountImageBridges.Remove(bridge);

            dbContext.Images.Remove(bridge.Stern);

            dbContext.Thumbnails.Remove(bridge.Stern.Thumbnail);

            dbContext.SaveChanges(User.Identity.Name);

            imageFileManager.DeleteImageFile(bridge.Stern);

            thumbnailFileManager.DeleteThumbnailFile(bridge.Stern.Thumbnail);

            return Ok();
        }
    }
}
