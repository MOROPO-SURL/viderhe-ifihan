using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Extensions;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    // TODO Firbid requiest for unprivileged moderators!!
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    public class ModeratorsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Moderator, System.Guid, ModeratorInputModel, ModeratorDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public ModeratorsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Moderator, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ModeratorsController> localizer, ILogger<ModeratorsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Moderator, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.AccountBridges.Any(b => b.ProwId == accountId);
        }

        public override ActionResult<ModeratorDisplayModel[]> Get()
        {
            return Ok(Repository.FindBy(GetGlobalSelector()).ToArray().Select(entity => EntityToDisplayModel(entity)).ToArray());
        }

        protected override void PreCreate(Moderator entity, ModeratorInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            if (inputModel.User.NewPassword != null)
            {
                entity.User.Password = inputModel.User.NewPassword.ToHashedPassword();
            }

            if (inputModel.Identity.Image != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(inputModel.Identity.Image.ContentData))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.Identity.Image = imageRepository.Add(new Image
                            {
                                ContentType = inputModel.Identity.Image.ContentType,
                                Length = inputModel.Identity.Image.ContentData.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Moderator: {0}", inputModel.Id)
                            }, User.Identity.Name, false);

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, inputModel.Identity.Image.ContentData, inputModel.Identity.Image.ContentType);
                        }
                    }
                }
            }

            entity.User.Signature = Framework.Guama.Security.Essential.Persistence.ORM.EF.Helpers.Integrity.UserIntegrityHelper.GetSignature(entity.User);
        }

        protected override void PostCreate(Moderator entity, ModeratorInputModel inputModel)
        {
            base.PostCreate(entity, inputModel);

            entity.AccountBridges.Add(new AccountModeratorBridge
            {
                SternId = entity.Id,
                ProwId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value)
            });

            Repository.Update(entity, User.Identity.Name);
        }

        protected override void PreEdit(Moderator entity, ModeratorInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            if (inputModel.User.NewPassword != null)
            {
                entity.User.Password = inputModel.User.NewPassword.ToHashedPassword();
            }

            if (inputModel.Identity.Image != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(inputModel.Identity.Image.ContentData))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.Identity.Image = imageRepository.Add(new Image
                            {
                                ContentType = inputModel.Identity.Image.ContentType,
                                Length = inputModel.Identity.Image.ContentData.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Moderator: {0}", inputModel.Id)
                            }, User.Identity.Name, false);

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, inputModel.Identity.Image.ContentData, inputModel.Identity.Image.ContentType);
                        }
                    }
                }
            }

            entity.User.Signature = Framework.Guama.Security.Essential.Persistence.ORM.EF.Helpers.Integrity.UserIntegrityHelper.GetSignature(entity.User);
        }

        protected override void PostEdit(Moderator entity, ModeratorInputModel inputModel)
        {
            base.PostEdit(entity, inputModel);

            if (inputModel.Identity.Image != null)
            {
                if (inputModel.Identity.Image.Id == default) return;

                var oldLogoImage = imageRepository.Get(inputModel.Identity.Image.Id);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }
        }

        protected override void PostDelete(Moderator entity)
        {
            base.PostDelete(entity);

            if (entity.Identity.Image != null)
            {
                imageRepository.Delete(entity.Identity.Image, User.Identity.Name);

                imageFileManager.DeleteImageFile(entity.Identity.Image);
            }
        }
    }
}
