using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Extensions;
using MOROPO.VIDERHE.Cloud.Options;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    // TODO Firbid requiest for unprivileged moderators!!
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[controller]")]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class AccountController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Account, System.Guid, AccountInputModel, AccountDisplayModel>
    {
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<Thumbnail, System.Guid> thumbnailRepository;
        private readonly IEntityRepository<Extension, System.Guid> extensionRepository;
        private readonly Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions;

        public AccountController(Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions, IEntityRepository<Extension, System.Guid> extensionRepository, IEntityRepository<Thumbnail, System.Guid> thumbnailRepository, IEntityRepository<Image, System.Guid> imageRepository, IThumbnailFileManagerFacade thumbnailFileManager, IImageFileManagerFacade imageFileManager, IEntityRepository<Account, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AccountController> localizer, ILogger<AccountController> logger) : base(repository, localizer, logger)
        {
            this.imageFileManager = imageFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
            this.imageRepository = imageRepository;
            this.thumbnailRepository = thumbnailRepository;
            this.extensionRepository = extensionRepository;
            this.mediaThumbnailResizeOptions = mediaThumbnailResizeOptions;
        }

        [HttpGet("[action]")]
        public ActionResult Current()
        {
            var entity = Repository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            var model = new AccountDisplayModel();

            model.Import(entity);

            foreach (var bridge in entity.ExtensionBridges)
            {
                var extension = extensionRepository.Get(bridge.SternId);

                var extensionDisplayModel = new ExtensionDisplayModel();

                extensionDisplayModel.Import(extension);

                model.Extensions.Add(extensionDisplayModel);
            }

            return Ok(model);
        }

        public override ActionResult<AccountDisplayModel[]> Get()
        {
            return NotFound();
        }

        public override ActionResult<AccountDisplayModel> Get(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<AccountDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return NotFound();
        }

        public override ActionResult Create([FromBody] AccountInputModel inputModel)
        {
            return NotFound();
        }

        public override ActionResult Edit([FromBody] AccountInputModel inputModel)
        {
            if (inputModel.Id != System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value))
            {
                return Forbid();
            }

            return base.Edit(inputModel);
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreEdit(Account entity, AccountInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            SkiaSharp.SKImageInfo desiredImageInfo;

            if (inputModel.LogoImageData != null)
            {
                using (var imageSkData = SkiaSharp.SKData.CreateCopy(inputModel.LogoImageData))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var image = imageRepository.Add(new Image
                        {
                            ContentType = inputModel.LogoImageContentType,
                            Length = inputModel.LogoImageData.Length,
                            Width = imageSkBitmap.Width,
                            Height = imageSkBitmap.Height,
                            About = "Account Logo " + entity.Id
                        }, User.Identity.Name, false);

                        imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                        inputModel.LogoImageId = entity.Logo.Id;

                        entity.Logo = image;
                        entity.LogoId = image.Id;

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

                                entity.Logo.Thumbnail = thumbnailRepository.Add(new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail for Logo: {0}", entity.Logo.About))
                                }, User.Identity.Name, false);

                                thumbnailFileManager.SaveThumbnailFileContent(entity.Logo.Thumbnail.Id, thumbnailSkData.ToArray(), entity.Logo.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }

            if (inputModel.HorizontalSplashImageData != null)
            {
                using (var imageSkData = SkiaSharp.SKData.CreateCopy(inputModel.HorizontalSplashImageData))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var image = imageRepository.Add(new Image
                        {
                            ContentType = inputModel.HorizontalSplashImageContentType,
                            Length = inputModel.HorizontalSplashImageData.Length,
                            Width = imageSkBitmap.Width,
                            Height = imageSkBitmap.Height,
                            About = "Account Horizontal Splash " + entity.Id
                        }, User.Identity.Name, false);

                        imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                        inputModel.HorizontalSplashImageId = entity.HorizontalSplash.Id;

                        entity.HorizontalSplash = image;
                        entity.HorizontalSplashId = image.Id;

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

                                entity.HorizontalSplash.Thumbnail = thumbnailRepository.Add(new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail: {0}", entity.HorizontalSplash.About))
                                }, User.Identity.Name, false);

                                thumbnailFileManager.SaveThumbnailFileContent(entity.HorizontalSplash.Thumbnail.Id, thumbnailSkData.ToArray(), entity.HorizontalSplash.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }

            if (inputModel.VerticalSplashImageData != null)
            {
                using (var imageSkData = SkiaSharp.SKData.CreateCopy(inputModel.VerticalSplashImageData))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var image = imageRepository.Add(new Image
                        {
                            ContentType = inputModel.VerticalSplashImageContentType,
                            Length = inputModel.VerticalSplashImageData.Length,
                            Width = imageSkBitmap.Width,
                            Height = imageSkBitmap.Height,
                            About = "Account Vertical Splash " + entity.Id
                        }, User.Identity.Name, false);

                        imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                        inputModel.VerticalSplashImageId = entity.VerticalSplash.Id;

                        entity.VerticalSplash = image;
                        entity.VerticalSplashId = image.Id;

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

                                entity.VerticalSplash.Thumbnail = thumbnailRepository.Add(new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail: {0}", entity.VerticalSplash.About))
                                }, User.Identity.Name, false);

                                thumbnailFileManager.SaveThumbnailFileContent(entity.VerticalSplash.Thumbnail.Id, thumbnailSkData.ToArray(), entity.VerticalSplash.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }

            entity.Signature = Helpers.Integrity.AccountIntegrityHelper.GetSignature(entity);
        }

        protected override void PostEdit(Account entity, AccountInputModel modelInput)
        {
            base.PostEdit(entity, modelInput);

            if (modelInput.LogoImageData != null)
            {
                var oldLogoImage = imageRepository.Get(modelInput.LogoImageId);

                imageRepository.Delete(oldLogoImage, User.Identity.Name, false);

                if (oldLogoImage.Thumbnail != null) thumbnailRepository.Delete(oldLogoImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);

                if (oldLogoImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldLogoImage.Thumbnail);
            }

            if (modelInput.HorizontalSplashImageData != null)
            {
                var oldSplashImage = imageRepository.Get(modelInput.HorizontalSplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name, false);

                if (oldSplashImage.Thumbnail != null) thumbnailRepository.Delete(oldSplashImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldSplashImage);

                if (oldSplashImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldSplashImage.Thumbnail);
            }

            if (modelInput.VerticalSplashImageData != null)
            {
                var oldSplashImage = imageRepository.Get(modelInput.VerticalSplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name, false);

                if (oldSplashImage.Thumbnail != null) thumbnailRepository.Delete(oldSplashImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldSplashImage);

                if (oldSplashImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldSplashImage.Thumbnail);
            }
        }
    }
}
