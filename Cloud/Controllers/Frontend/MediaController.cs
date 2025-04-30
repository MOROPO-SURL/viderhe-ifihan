using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Cloud.Extensions;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    public class MediaController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;
        private readonly IEntityRepository<Moderator, System.Guid> moderatorRepository;
        private readonly IBridgeRepository<AccountImageBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid> accountImageBridgeRepository;
        private readonly IBridgeRepository<AccountVideoBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Video, System.Guid> accountVideoBridgeRepository;
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;

        public MediaController(IBridgeRepository<AccountVideoBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Video, System.Guid> accountVideoBridgeRepository, IBridgeRepository<AccountImageBridge, Account, System.Guid, Framework.Guama.Media.Persistence.Entities.Image, System.Guid> accountImageBridgeRepository, IEntityRepository<Moderator, System.Guid> moderatorRepository, IEntityRepository<Account, System.Guid> accountRepository, IImageFileManagerFacade imageFileManager, IThumbnailFileManagerFacade thumbnailFileManager, Microsoft.Extensions.Localization.IStringLocalizer<MediaController> localizer, ILogger<MediaController> logger)
            : base(localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.moderatorRepository = moderatorRepository;
            this.accountImageBridgeRepository = accountImageBridgeRepository;
            this.accountVideoBridgeRepository = accountVideoBridgeRepository;
            this.imageFileManager = imageFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
        }

        [HttpGet("[action]/{key}")]
        public IActionResult Image(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                var image = accountImageBridgeRepository.FindOneBy(bridge => bridge.ProwId == account.Id && bridge.SternId == key)?.Stern;

                return new FileContentResult(imageFileManager.GetImageFileContent(image), image.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.Message, e.InnerException);
            }

            return new NoContentResult();
        }

        [HttpGet("[action]/{key}/w/{width}/h/{height}")]
        public IActionResult Image(System.Guid key, int width, int height)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                var image = accountImageBridgeRepository.FindOneBy(bridge => bridge.ProwId == account.Id && bridge.SternId == key)?.Stern;

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
            catch (System.Exception e)
            {
                logger.LogError(e.Message, e.InnerException);
            }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/image/{key}")]
        public IActionResult ImageThumbnail(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                var thumbnail = accountImageBridgeRepository.Get(account.Id, key).Stern.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/video/{key}")]
        public IActionResult VideoThumbnail(System.Guid key)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                var thumbnail = accountVideoBridgeRepository.Get(account.Id, key).Stern.Thumbnail;

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(thumbnail), thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

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
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("[action]")]
        public IActionResult Logo()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(imageFileManager.GetImageFileContent(account.Logo), account.Logo.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/logo")]
        public IActionResult LogoThumbnail()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(account.Logo.Thumbnail), account.Logo.Thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("splash/horizontal")]
        public IActionResult HorizontalSplash()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("splash/horizontal/w/{width}/h/{height}")]
        public IActionResult HorizontalSplash(int width, int height)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                if (account.HorizontalSplash.Width > 0 && account.HorizontalSplash.Height > 0 && account.HorizontalSplash.Width <= width && account.HorizontalSplash.Height <= height)
                {
                    return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
                }

                byte[] resultContent = null;

                using (var imageStream = new System.IO.MemoryStream(imageFileManager.GetImageFileContent(account.HorizontalSplash)))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            SkiaSharp.SKImageInfo desiredImageInfo;

                            if (imageSkBitmap.Width <= width && imageSkBitmap.Height <= height)
                            {
                                return new FileContentResult(imageFileManager.GetImageFileContent(account.HorizontalSplash), account.HorizontalSplash.ContentType);
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
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/splash/horizontal")]
        public IActionResult HorizontalSplashThumbnail()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(account.HorizontalSplash.Thumbnail), account.HorizontalSplash.Thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("splash/vertical")]
        public IActionResult VerticalSplash()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(imageFileManager.GetImageFileContent(account.VerticalSplash), account.VerticalSplash.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("splash/vertical/w/{width}/h/{height}")]
        public IActionResult VerticalSplash(int width, int height)
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                if (account.VerticalSplash.Width > 0 && account.VerticalSplash.Height > 0 && account.VerticalSplash.Width <= width && account.VerticalSplash.Height <= height)
                {
                    return new FileContentResult(imageFileManager.GetImageFileContent(account.VerticalSplash), account.VerticalSplash.ContentType);
                }

                byte[] resultContent = null;

                using (var imageStream = new System.IO.MemoryStream(imageFileManager.GetImageFileContent(account.VerticalSplash)))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            SkiaSharp.SKImageInfo desiredImageInfo;

                            if (imageSkBitmap.Width <= width && imageSkBitmap.Height <= height)
                            {
                                return new FileContentResult(imageFileManager.GetImageFileContent(account.VerticalSplash), account.VerticalSplash.ContentType);
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
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }

        [HttpGet("thumbnail/splash/vertical")]
        public IActionResult VerticalSplashThumbnail()
        {
            try
            {
                var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

                return new FileContentResult(thumbnailFileManager.GetThumbnailFileContent(account.VerticalSplash.Thumbnail), account.VerticalSplash.Thumbnail.ContentType);
            }
            catch (System.IO.IOException e)
            {
                logger.LogError(e.Message, e.InnerException);
            }
            catch (System.Exception e) { logger.LogError(e.Message, e.InnerException); }

            return new NoContentResult();
        }
    }
}
