using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Videre.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Videre.Cloud.Persistence.Entities;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    [Route("api/[area]/[controller]")]
    [Area("business")]
    [SAPRESSC.Core.Web.Security.Filters.ChangeUserPasswordRequiredAction]
    [SAPRESSC.Core.Web.Security.Filters.CatchChangeUserPasswordRequiredException]
    public class AccountController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Account, System.Guid, AccountInputModel, AccountDisplayModel>
    {
        private readonly SAPRESSC.Middleware.Media.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager;
        private readonly IEntityRepository<SAPRESSC.Middleware.Media.Persistence.Entities.Image, System.Guid> imageRepository;
        private readonly IEntityRepository<Extension, System.Guid> extensionRepository;

        public AccountController(IEntityRepository<Extension, System.Guid> extensionRepository, IEntityRepository<SAPRESSC.Middleware.Media.Persistence.Entities.Image, System.Guid> imageRepository, SAPRESSC.Middleware.Media.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager, IEntityRepository<Account, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AccountController> localizer, ILogger<AccountController> logger) : base(repository, localizer, logger)
        {
            this.imageFileManager = imageFileManager;
            this.imageRepository = imageRepository;
            this.extensionRepository = extensionRepository;
        }

        [HttpGet("[action]")]
        public ActionResult Current()
        {
            var entity = Repository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            var model = new AccountDisplayModel();

            model.Import(entity);

            foreach (var bridge in entity.ExtensionBridges)
            {
                var extension = extensionRepository.Get(bridge.ExtensionId);

                var extensionDisplayModel = new ExtensionDisplayModel();

                extensionDisplayModel.Import(extension);

                model.Extensions.Add(extensionDisplayModel);
            }

            return Ok(model);
        }

        public override IActionResult Get()
        {
            return NotFound();
        }

        public override IActionResult Get(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult GetPaginate(int sheet = 1, int limit = 25)
        {
            return NotFound();
        }

        public override IActionResult Create([FromBody] AccountInputModel inputModel)
        {
            return NotFound();
        }

        public override IActionResult Edit([FromBody] AccountInputModel inputModel)
        {
            if (inputModel.Id != System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value))
            {
                return Forbid();
            }

            return base.Edit(inputModel);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreEdit(Account entity, AccountInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            if (inputModel.LogoImageData != null)
            {
                using (var imageSkData = SkiaSharp.SKData.CreateCopy(inputModel.LogoImageData))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var image = new SAPRESSC.Middleware.Media.Persistence.Entities.Image
                        {
                            ContentType = inputModel.LogoImageContentType,
                            Length = inputModel.LogoImageData.Length,
                            Width = imageSkBitmap.Width,
                            Height = imageSkBitmap.Height,
                            About = "Account Logo " + entity.Id
                        };

                        imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                        inputModel.LogoImageId = entity.Logo.Id;

                        entity.Logo = image;
                    }
                }
            }

            if (inputModel.SplashImageData != null)
            {
                using (var imageSkData = SkiaSharp.SKData.CreateCopy(inputModel.SplashImageData))
                {
                    using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                    {
                        var image = new SAPRESSC.Middleware.Media.Persistence.Entities.Image
                        {
                            ContentType = inputModel.SplashImageContentType,
                            Length = inputModel.SplashImageData.Length,
                            Width = imageSkBitmap.Width,
                            Height = imageSkBitmap.Height,
                            About = "Account Splash " + entity.Id
                        };

                        imageFileManager.SaveImageFileContent(image.Id, imageSkData.ToArray(), image.ContentType);

                        inputModel.SplashImageId = entity.Splash.Id;

                        entity.Splash = image;
                    }
                }
            }

            entity.Signature = Helpers.Integrity.AccountIntegrityHelper.GetSignature(entity);
        }

        protected override void PostEdit(Account entity, AccountInputModel inputModel)
        {
            base.PostEdit(entity, inputModel);

            if (inputModel.LogoImageData != null)
            {
                var oldLogoImage = imageRepository.Get(inputModel.LogoImageId);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }

            if (inputModel.SplashImageData != null)
            {
                var oldSplashImage = imageRepository.Get(inputModel.SplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldSplashImage);
            }
        }
    }
}
