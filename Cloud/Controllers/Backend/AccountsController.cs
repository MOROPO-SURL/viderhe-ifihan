using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models.View;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.Framework.Guama.Security.Essential.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Extensions;
using MOROPO.VIDERHE.Cloud.Models.View;
using MOROPO.VIDERHE.Cloud.Options;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("business")]
    public class AccountsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractHabilitableEntityManagementController<Account, System.Guid, AccountInputViewModel, AccountDisplayViewModel>
    {
        private const string LOGO_IMAGE_FILE_FIELD_NAME = "LogoImageFile";
        private const string HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME = "HorizontalSplashImageFile";
        private const string VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME = "VerticalSplashImageFile";

        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;
        private readonly IEntityRepository<User, string> userRepository;
        private readonly IEntityRepository<Extension, System.Guid> extensionRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<PersonIdentity, System.Guid> identityRepository;
        private readonly IEntityRepository<Moderator, System.Guid> moderatorRepository;
        private readonly IEntityRepository<Thumbnail, System.Guid> thumbnailRepository;
        private readonly Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions;

        public AccountsController(Microsoft.Extensions.Options.IOptions<MediaThumbnailResizeOptions> mediaThumbnailResizeOptions, IEntityRepository<Thumbnail, System.Guid> thumbnailRepository, IEntityRepository<Moderator, System.Guid> moderatorRepository, IEntityRepository<PersonIdentity, System.Guid> identityRepository, IThumbnailFileManagerFacade thumbnailFileManager, IImageFileManagerFacade imageFileManager, IEntityRepository<User, string> userRepository, IEntityRepository<Extension, System.Guid> extensionRepository, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Account, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AccountsController> localizer, ILogger<AccountsController> logger) : base(repository, localizer, logger)
        {
            this.imageFileManager = imageFileManager;
            this.userRepository = userRepository;
            this.extensionRepository = extensionRepository;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.moderatorRepository = moderatorRepository;
            this.thumbnailRepository = thumbnailRepository;
            this.thumbnailFileManager = thumbnailFileManager;
            this.mediaThumbnailResizeOptions = mediaThumbnailResizeOptions;
        }

        [RequirePermissions(Permission.AccountViewer)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Permission.AccountCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.AccountCreator)]
        public override IActionResult Create(AccountInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var validationRequired = false;

                var formLogoImageFile = Request.Form.Files.First(f => f.Name == LOGO_IMAGE_FILE_FIELD_NAME);

                if (formLogoImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);

                    modelInput.LogoImageFile = formLogoImageFile;

                    validationRequired = true;
                }

                var formHorizontalSplashImageFile = Request.Form.Files.First(f => f.Name == HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formHorizontalSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.HorizontalSplashImageFile = formHorizontalSplashImageFile;

                    validationRequired = true;
                }

                var formVerticalSplashImageFile = Request.Form.Files.First(f => f.Name == VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formVerticalSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.VerticalSplashImageFile = formVerticalSplashImageFile;

                    validationRequired = true;
                }

                if (validationRequired) TryUpdateModelAsync(modelInput).Wait();
            }

            return base.Create(modelInput);
        }

        protected override void PreCreate(Account entity, AccountInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            SkiaSharp.SKImageInfo desiredImageInfo;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.LogoImageFile.CopyTo(memoryStream);

                memoryStream.Position = 0;

                using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var logoImage = new Image { ContentType = modelInput.LogoImageFile.ContentType, Length = modelInput.LogoImageFile.Length, About = "Account Logo " + entity.Id, Width = imageSkBitmap.Width, Height = imageSkBitmap.Height };

                        imageFileManager.SaveImageFileContent(logoImage.Id, memoryStream.ToArray(), modelInput.LogoImageFile.ContentType);

                        entity.Logo = logoImage;

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

                                logoImage.Thumbnail = new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail: {0}", logoImage.About))
                                };

                                thumbnailFileManager.SaveThumbnailFileContent(logoImage.Thumbnail.Id, thumbnailSkData.ToArray(), logoImage.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.HorizontalSplashImageFile.CopyTo(memoryStream);

                memoryStream.Position = 0;

                using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var splashImage = new Image { ContentType = modelInput.HorizontalSplashImageFile.ContentType, Length = modelInput.HorizontalSplashImageFile.Length, About = "Account Horizontal Splash " + entity.Id };

                        imageFileManager.SaveImageFileContent(splashImage.Id, memoryStream.ToArray(), modelInput.HorizontalSplashImageFile.ContentType);

                        entity.HorizontalSplash = splashImage;

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

                                splashImage.Thumbnail = new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail: {0}", splashImage.About))
                                };

                                thumbnailFileManager.SaveThumbnailFileContent(splashImage.Thumbnail.Id, thumbnailSkData.ToArray(), splashImage.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.VerticalSplashImageFile.CopyTo(memoryStream);

                memoryStream.Position = 0;

                using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var splashImage = new Image { ContentType = modelInput.VerticalSplashImageFile.ContentType, Length = modelInput.VerticalSplashImageFile.Length, About = "Account Vertical Splash " + entity.Id };

                        imageFileManager.SaveImageFileContent(splashImage.Id, memoryStream.ToArray(), modelInput.VerticalSplashImageFile.ContentType);

                        entity.VerticalSplash = splashImage;

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

                                splashImage.Thumbnail = new Thumbnail
                                {
                                    ContentType = "image/png",
                                    Length = thumbnailSkData.Size,
                                    About = string.Format(string.Format("Thumbnail: {0}", splashImage.About))
                                };

                                thumbnailFileManager.SaveThumbnailFileContent(splashImage.Thumbnail.Id, thumbnailSkData.ToArray(), splashImage.Thumbnail.ContentType);
                            }
                        }
                    }
                }
            }
        }

        [RequirePermissions(Permission.AccountEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.AccountEditor)]
        public override IActionResult Edit(AccountInputViewModel modelInput)
        {
            ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);
            ModelState.MarkFieldValid(LOGO_IMAGE_FILE_FIELD_NAME);

            ModelState.ClearValidationState(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);
            ModelState.MarkFieldValid(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);

            ModelState.ClearValidationState(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);
            ModelState.MarkFieldValid(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);

            if (Request.Form.Files.Count > 0)
            {
                var validationRequired = false;

                var formLogoImageFile = Request.Form.Files.FirstOrDefault(f => f.Name == LOGO_IMAGE_FILE_FIELD_NAME);

                if (formLogoImageFile != null && formLogoImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);

                    modelInput.LogoImageFile = formLogoImageFile;

                    validationRequired = true;
                }

                var formHorizontalSplashImageFile = Request.Form.Files.FirstOrDefault(f => f.Name == HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formHorizontalSplashImageFile != null && formHorizontalSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.HorizontalSplashImageFile = formHorizontalSplashImageFile;

                    validationRequired = true;
                }

                var formVerticalSplashImageFile = Request.Form.Files.FirstOrDefault(f => f.Name == VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formVerticalSplashImageFile != null && formVerticalSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.VerticalSplashImageFile = formVerticalSplashImageFile;

                    validationRequired = true;
                }

                if (validationRequired)
                {
                    TryUpdateModelAsync(modelInput).Wait();

                    if (modelInput.LogoImageFile == null)
                    {
                        ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);
                        ModelState.MarkFieldValid(LOGO_IMAGE_FILE_FIELD_NAME);
                    }

                    if (modelInput.HorizontalSplashImageFile == null)
                    {
                        ModelState.ClearValidationState(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);
                        ModelState.MarkFieldValid(HORIZONTAL_SPLASH_IMAGE_FILE_FIELD_NAME);
                    }

                    if (modelInput.VerticalSplashImageFile == null)
                    {
                        ModelState.ClearValidationState(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);
                        ModelState.MarkFieldValid(VERTICAL_SPLASH_IMAGE_FILE_FIELD_NAME);
                    }
                }
            }

            return base.Edit(modelInput);
        }

        protected override void PreEdit(Account entity, AccountInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            SkiaSharp.SKImageInfo desiredImageInfo;

            if (modelInput.LogoImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.LogoImageFile.CopyTo(memoryStream);

                    memoryStream.Position = 0;

                    using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.Logo = imageRepository.Add(new Image 
                            { 
                                ContentType = modelInput.LogoImageFile.ContentType, 
                                Length = modelInput.LogoImageFile.Length, About = "Account Logo " + entity.Id,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height
                            }, User.Identity.Name, false);

                            imageFileManager.SaveImageFileContent(entity.Logo.Id, memoryStream.ToArray(), modelInput.LogoImageFile.ContentType);

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
                                        About = string.Format(string.Format("Thumbnail: {0}", entity.Logo.About))
                                    }, User.Identity.Name, false);

                                    thumbnailFileManager.SaveThumbnailFileContent(entity.Logo.Thumbnail.Id, thumbnailSkData.ToArray(), entity.Logo.Thumbnail.ContentType);
                                }
                            }
                        }
                    }
                }
            }

            if (modelInput.HorizontalSplashImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.HorizontalSplashImageFile.CopyTo(memoryStream);

                    memoryStream.Position = 0;

                    using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.HorizontalSplash = imageRepository.Add(new Image { 
                                ContentType = modelInput.HorizontalSplashImageFile.ContentType, 
                                Length = modelInput.HorizontalSplashImageFile.Length, 
                                About = "Account Horizontal Splash " + entity.Id,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height
                            }, User.Identity.Name, false);

                            imageFileManager.SaveImageFileContent(entity.HorizontalSplash.Id, memoryStream.ToArray(), modelInput.HorizontalSplashImageFile.ContentType);

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
            }

            if (modelInput.VerticalSplashImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.VerticalSplashImageFile.CopyTo(memoryStream);

                    memoryStream.Position = 0;

                    using (var imageSkData = SkiaSharp.SKData.Create(memoryStream, memoryStream.Length))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.VerticalSplash = imageRepository.Add(new Image { 
                                ContentType = modelInput.VerticalSplashImageFile.ContentType, 
                                Length = modelInput.VerticalSplashImageFile.Length, 
                                About = "Account Vertical Splash " + entity.Id,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height
                            }, User.Identity.Name, false);

                            imageFileManager.SaveImageFileContent(entity.VerticalSplash.Id, memoryStream.ToArray(), modelInput.VerticalSplashImageFile.ContentType);

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
            }
        }

        protected override void PostEdit(Account entity, AccountInputViewModel modelInput)
        {
            base.PostEdit(entity, modelInput);

            if (modelInput.LogoImageFile != null)
            {
                var oldLogoImage = imageRepository.Get(modelInput.LogoImageId);

                imageRepository.Delete(oldLogoImage, User.Identity.Name, false);

                if (oldLogoImage.Thumbnail != null) thumbnailRepository.Delete(oldLogoImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);

                if (oldLogoImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldLogoImage.Thumbnail);
            }

            if (modelInput.HorizontalSplashImageFile != null)
            {
                var oldSplashImage = imageRepository.Get(modelInput.HorizontalSplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name, false);

                if (oldSplashImage.Thumbnail != null) thumbnailRepository.Delete(oldSplashImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldSplashImage);

                if (oldSplashImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldSplashImage.Thumbnail);
            }

            if (modelInput.VerticalSplashImageFile != null)
            {
                var oldSplashImage = imageRepository.Get(modelInput.VerticalSplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name, false);

                if (oldSplashImage.Thumbnail != null) thumbnailRepository.Delete(oldSplashImage.Thumbnail, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldSplashImage);

                if (oldSplashImage.Thumbnail != null) thumbnailFileManager.DeleteThumbnailFile(oldSplashImage.Thumbnail);
            }
        }

        [RequirePermissions(Permission.AccountEditor)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Permission.AccountEditor)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Permission.AccountRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.AccountRemover)]
        public override IActionResult Delete(AccountDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PostDelete(Account entity)
        {
            base.PostDelete(entity);

            imageRepository.Delete(entity.Logo, User.Identity.Name);

            imageFileManager.DeleteImageFile(entity.Logo);

            imageRepository.Delete(entity.HorizontalSplash, User.Identity.Name);

            imageFileManager.DeleteImageFile(entity.HorizontalSplash);

            imageRepository.Delete(entity.VerticalSplash, User.Identity.Name);

            imageFileManager.DeleteImageFile(entity.VerticalSplash);
        }

        #region Account Moderators Management

        [HttpGet]
        [Route("edit/{key}/moderators")]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult Moderators(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var model = new AccountModeratorsViewModel
                {
                    Account = new AccountDisplayViewModel(),
                    Moderators = entity.ModeratorBridges.Select(e =>
                    {
                        var displayModel = new ModeratorDisplayViewModel();

                        displayModel.Import(e.Stern);

                        return displayModel;
                    }).ToList()
                };

                model.Account.Import(entity);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpGet]
        [Route("edit/{key}/moderators/add")]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult AddModerator(System.Guid key)
        {
            try
            {
                var account = Repository.Get(key);

                var model = new ModeratorInputViewModel
                {
                    SelectableUsers = userRepository.GetAll().ToArray().Except(account.ModeratorBridges.Select(b => b.Stern.User).ToArray()).ToArray().Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = e.Id,
                        Text = e.Id
                    }).ToList()
                };

                model.Account.Import(account);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/add")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult AddModerator(System.Guid key, ModeratorInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    ModelState.ClearValidationState("ImageFile");

                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            try
            {
                var entity = Repository.Get(key);

                if (ModelState.IsValid)
                {
                    try
                    {
                        var moderator = moderatorRepository.Add(modelInput.Export(), User.Identity.Name, false);

                        var bridge = new AccountModeratorBridge
                        {
                            ProwId = entity.Id,
                            Stern = moderator
                        };

                        bridge.Stern.ModerationKind = ModerationKind.Privileged;

                        if (modelInput.ImageFile != null)
                        {
                            using (var memoryStream = new System.IO.MemoryStream())
                            {
                                modelInput.ImageFile.CopyTo(memoryStream);

                                bridge.Stern.Identity.Image = imageRepository.Add(new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Moderator for Account " + entity.Id }, User.Identity.Name, false);

                                imageFileManager.SaveImageFileContent(bridge.Stern.Identity.Image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);
                            }
                        }

                        entity.ModeratorBridges.Add(bridge);

                        Repository.Update(entity, User.Identity.Name);

                        SetDefaultNotification(NotificationType.Success, GetCreationSuccessMessage());

                        return RedirectToAction("moderators", new { key = entity.Id });
                    }
                    catch (Framework.Guama.Core.Presentation.Web.Frontend.InvalidModelException e)
                    {
                        ModelState.AddModelError(e.ModelKey, e.ErrorMessage);
                    }
                }

                SetDefaultNotification(NotificationType.Danger, GetInvalidMessage());

                modelInput.SelectableUsers = userRepository.GetAll().ToArray().Except(entity.ModeratorBridges.Select(b => b.Stern.User).ToArray()).ToArray().Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = e.Id,
                    Text = e.Id
                }).ToList();

                modelInput.Account.Import(entity);

                return View(modelInput);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpGet]
        [Route("edit/{key}/moderators/edit/{id}")]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult EditModerator(System.Guid key, System.Guid id)
        {
            try
            {
                var account = Repository.Get(key);

                var entity = account.ModeratorBridges.First(b => b.SternId == id).Stern;

                var model = new ModeratorInputViewModel();

                model.Import(entity);
                model.Account.Import(account);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/edit")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult EditModerator(System.Guid key, ModeratorInputViewModel modelInput)
        {
            ModelState.ClearValidationState("ImageFile");
            ModelState.MarkFieldValid("ImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = Repository.Get(key);

                    try
                    {
                        var bridge = entity.ModeratorBridges.First(b => b.SternId == modelInput.Id);

                        modelInput.Mergue(bridge.Stern);

                        if (modelInput.ImageFile == null)
                        {
                            if (modelInput.ResetImage && bridge.Stern.Identity.Image != null)
                            {
                                imageFileManager.DeleteImageFile(bridge.Stern.Identity.Image);

                                imageRepository.Delete(bridge.Stern.Identity.Image, User.Identity.Name);
                            }
                        }
                        else
                        {
                            if (bridge.Stern.Identity.Image != null)
                            {
                                imageFileManager.DeleteImageFile(bridge.Stern.Identity.Image);

                                imageRepository.Delete(bridge.Stern.Identity.Image, User.Identity.Name);
                            }

                            using (var memoryStream = new System.IO.MemoryStream())
                            {
                                modelInput.ImageFile.CopyTo(memoryStream);

                                bridge.Stern.Identity.Image = imageRepository.Add(new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Moderator " + entity.Id }, User.Identity.Name, false);

                                imageFileManager.SaveImageFileContent(bridge.Stern.Identity.Image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);
                            }
                        }

                        Repository.Update(entity, User.Identity.Name);

                        SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

                        return RedirectToAction("moderators", new { key = entity.Id });
                    }
                    catch (Framework.Guama.Core.Presentation.Web.Frontend.InvalidModelException e)
                    {
                        ModelState.AddModelError(e.ModelKey, e.ErrorMessage);
                    }

                    SetDefaultNotification(NotificationType.Danger, GetInvalidMessage());

                    modelInput.Account.Import(entity);

                    return View(modelInput);
                }
                catch (System.Exception e)
                {
                    logger.LogError(e.InnerException, e.Message);
                }
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/delete")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult DeleteModerator(System.Guid key, ModeratorDisplayViewModel modelInput)
        {
            try
            {
                var entity = Repository.Get(key);

                var bridge = entity.ModeratorBridges.First(b => b.SternId == modelInput.Id);

                entity.ModeratorBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name, false);

                identityRepository.Delete(bridge.Stern.Identity, User.Identity.Name, false);

                var image = bridge.Stern.Identity.Image;

                if (bridge.Stern.Identity.Image != null)
                {
                    imageRepository.Delete(bridge.Stern.Identity.Image, User.Identity.Name, false);
                }

                moderatorRepository.Delete(bridge.Stern, User.Identity.Name);

                if (image != null)
                {
                    imageFileManager.DeleteImageFile(image);
                }

                SetDefaultNotification(NotificationType.Success, GetDeletionSuccessMessage());

                return RedirectToAction("moderators", new { key = entity.Id });
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());

                return RedirectToAction("moderators", new { key });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetSuccessDeleteActionResult();
        }

        #endregion

        #region Account Extension Management

        [HttpGet]
        [Route("[action]/{key}")]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult Extensions(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var modelInput = new AccountExtensionsInputViewModel
                {
                    AccountId = entity.Id,
                    Account = entity
                };

                var plugins = extensionRepository.GetAll().ToArray();

                foreach (var plugin in plugins)
                {
                    var descriptor = Support.Extend.Providers.ExtensionDescriptorProvider.Instance.GetDescriptorById(plugin.Id);

                    modelInput.SelectableExtensions.Add(new Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>
                    {
                        Id = plugin.Id,
                        Selected = false,
                        Label = descriptor.Name,
                        Description = descriptor.Description
                    });
                }

                foreach (var item in modelInput.SelectableExtensions)
                {
                    item.Selected = entity.ExtensionBridges.Any(bridge => Helpers.Integrity.AccountExtensionBridgeIntegrityHelper.IsCorrectlySigned(bridge) && bridge.SternId == item.Id);
                }

                return View(modelInput);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        [RequirePermissions(Permission.AccountEditor)]
        public IActionResult Extensions(AccountExtensionsInputViewModel modelInput)
        {
            try
            {
                var entity = Repository.Get(modelInput.AccountId);

                entity.ExtensionBridges.Clear();

                Repository.Update(entity, User.Identity.Name);

                foreach (var item in modelInput.SelectableExtensions.Where(item => item.Selected))
                {
                    var bridge = new AccountExtensionBridge
                    {
                        ProwId = entity.Id,
                        SternId = item.Id
                    };

                    bridge.Signature = Helpers.Integrity.AccountExtensionBridgeIntegrityHelper.GetSignature(bridge);

                    entity.ExtensionBridges.Add(bridge);
                }

                Repository.Update(entity, User.Identity.Name);

                modelInput.Account = entity;

                SetDefaultNotification(NotificationType.Success, GetEditionSuccessMessage());

                return RedirectToAction("extensions", new { key = entity.Id });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        # endregion
    }
}
