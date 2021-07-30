using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.SAPRESSC.Middleware.Media.Web.Common.Managers.Facade;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    public class MediaController : SAPRESSC.Core.Web.Common.Controllers.BaseWebController
    {
        private readonly SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository;
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;

        public MediaController(SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository, IImageFileManagerFacade imageFileManager, IThumbnailFileManagerFacade thumbnailFileManager, Microsoft.Extensions.Localization.IStringLocalizer<MediaController> localizer, ILogger<MediaController> logger)
            : base(localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.imageFileManager = imageFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
        }

        [HttpGet("[action]/{key}")]
        public IActionResult Image(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

                var image = account.ImageBridges.First(b => b.ImageId == key).Image;

                return new FileContentResult(imageFileManager.GetImageFileContent(image), image.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NotFoundResult();
        }

        [HttpGet("[action]/{key}")]
        public IActionResult ImageThumbnail(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

                var thumbnail = account.ImageBridges.First(b => b.Image.Thumbnail.Id == key).Image.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NotFoundResult();
        }

        [HttpGet("[action]/{key}")]
        public IActionResult VideoThumbnail(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

                var thumbnail = account.VideoBridges.First(b => b.Video.Thumbnail.Id == key).Video.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NotFoundResult();
        }

        [HttpGet("[action]")]
        public IActionResult Logo()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(imageFileManager.GetImageFileContent(account.Logo), account.Logo.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NotFoundResult();
        }

        [HttpGet("[action]")]
        public IActionResult Splash()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NotFoundResult();
        }
    }
}
