using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Cloud.Extensions;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [Area("business")]
    public class MediaController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;
        private readonly IEntityRepository<Moderator, System.Guid> moderatorRepository;
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;

        public MediaController(IEntityRepository<Moderator, System.Guid> moderatorRepository, IEntityRepository<Account, System.Guid> accountRepository, IImageFileManagerFacade imageFileManager, IThumbnailFileManagerFacade thumbnailFileManager, Microsoft.Extensions.Localization.IStringLocalizer<MediaController> localizer, ILogger<MediaController> logger)
            : base(localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.moderatorRepository = moderatorRepository;
            this.imageFileManager = imageFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
        }

        [HttpGet("[action]/{key}/account/{accountId}")]
        public IActionResult Image(System.Guid key, System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                var image = account.ImageBridges.First(b => b.SternId == key).Stern;

                return new FileContentResult(imageFileManager.GetImageFileContent(image), image.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("[action]/{key}/account/{accountId}/w/{width}/h/{height}")]
        public IActionResult Image(System.Guid key, System.Guid accountId, int width, int height)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                var image = account.ImageBridges.FirstOrDefault(b => b.SternId == key)?.Stern;

                if (image == null)
                {
                    if (account.LogoId == key)
                    {
                        image = account.Logo;
                    }
                    else if (account.HorizontalSplashId == key)
                    {
                        image = account.HorizontalSplash;
                    }
                    else if (account.VerticalSplashId == key)
                    {
                        image = account.VerticalSplash;
                    }
                    else
                    {
                        return new NoContentResult();
                    }
                }

                if (image.Width > 0 && image.Height > 0 && image.Width <= width && image.Height <= height)
                {
                    return new FileContentResult(imageFileManager.GetImageFileContent(image), image.ContentType);
                }

                byte[] resultContent = null;

                using (var imageStream = new System.IO.MemoryStream(imageFileManager.GetImageFileContent(image)))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            SkiaSharp.SKImageInfo desiredImageInfo;

                            if (imageSkBitmap.Width <= width && imageSkBitmap.Height <= height)
                            {
                                return new FileContentResult(imageFileManager.GetImageFileContent(image), image.ContentType);
                            }

                            logger.LogDebug(">>>>>>>>>>>>>>>>> Image shake required!!");

                            if (imageSkBitmap.Width > imageSkBitmap.Height)
                            {
                                desiredImageInfo = imageSkBitmap.Info.LandscapeScale(width);
                            }
                            else
                            {
                                desiredImageInfo = imageSkBitmap.Info.PortraitScale(height);
                            }

                            using (var cropSkBitmap = imageSkBitmap.Resize(desiredImageInfo, SkiaSharp.SKFilterQuality.High))
                            {
                                using (var cropSkImage = SkiaSharp.SKImage.FromBitmap(cropSkBitmap))
                                {
                                    var cropSkData = cropSkImage.Encode(SkiaSharp.SKEncodedImageFormat.Png, 75);

                                    resultContent = cropSkData.ToArray();
                                }
                            }
                        }
                    }
                }

                return new FileContentResult(resultContent, "image/png");
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpGet("[action]/{key}")]
        public IActionResult Moderator(System.Guid key)
        {
            try
            {
                var moderator = moderatorRepository.FindOneBy(entity => entity.Identity.ImageId == key);

                return new FileContentResult(imageFileManager.GetImageFileContent(moderator.Identity.Image), moderator.Identity.Image.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("[action]")]
        public IActionResult Logo(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.Logo), account.Logo.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("splah/vertical")]
        public IActionResult SplashVertical(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.VerticalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("splah/horizontal")]
        public IActionResult SplashHorizontal(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/image/{key}/account/{accountId}")]
        public IActionResult ImageThumbnail(System.Guid key, System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                var thumbnail = account.ImageBridges.First(b => b.Stern.Id == key).Stern.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/video/{key}/account/{accountId}")]
        public IActionResult VideoThumbnail(System.Guid key, System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                var thumbnail = account.VideoBridges.First(b => b.Stern.Id == key).Stern.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/logo/{accountId}")]
        public IActionResult ThumbnailLogo(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.Logo), account.Logo.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/splash/vertical/{accountId}")]
        public IActionResult ThumbnailSplashVertical(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.VerticalSplash), account.VerticalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/splash/horizontal/{accountId}")]
        public IActionResult ThumbnailSplashHorizontal(System.Guid accountId)
        {
            try
            {
                var account = accountRepository.Get(accountId);

                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch { }

            return new NoContentResult();
        }
    }
}
