using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSolucionesCuba.SAPRESSC.Middleware.Media.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Middleware.Media.Web.Common.Managers.Facade;
using SmartSolucionesCuba.Videre.Cloud.Api.Common.Models;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    [Route("api/[area]/[controller]")]
    [Area("business")]
    [ApiController]
    [SAPRESSC.Core.Web.Security.Filters.ChangeUserPasswordRequiredAction]
    [SAPRESSC.Core.Web.Security.Filters.CatchChangeUserPasswordRequiredException]
    public class VideosController : Controller
    {
        private readonly IVideoFileManagerFacade videoFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;
        private readonly Persistence.EF.ApplicationDbContext dbContext;
        private readonly Microsoft.Extensions.Options.IOptions<Options.FfmpegOptions> ffmpegOptions;
        private readonly SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Video, System.Guid> videoRepository;

        public VideosController(SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Video, System.Guid> videoRepository, IVideoFileManagerFacade videoFileManager, IThumbnailFileManagerFacade thumbnailFileManager, Persistence.EF.ApplicationDbContext dbContext, Microsoft.Extensions.Options.IOptions<Options.FfmpegOptions> ffmpegOptions)
        {
            this.videoFileManager = videoFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
            this.dbContext = dbContext;
            this.ffmpegOptions = ffmpegOptions;
            this.videoRepository = videoRepository;
        }

        [HttpGet]
        [HttpGet("page/{page}")]
        public IActionResult GetPage(int page = 1)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var limit = 50;

            var account = dbContext.Accounts.Include(e => e.VideoBridges).ThenInclude(b => b.Video).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var maxCount = account.VideoBridges.Count;

            var offset = (page - 1) * limit;

            return Ok(new SAPRESSC.Core.Common.Models.PaginationModel<VideoDisplayModel>
            {
                List = account.VideoBridges.Skip(offset).Take(limit).OrderByDescending(b => b.Video.CreateAt).Select((Persistence.Entities.AccountVideoBridge bridge) =>
                {
                    var model = new VideoDisplayModel();

                    model.Import(bridge.Video);

                    return model;
                }).ToList(),
                Limit = limit,
                Page = page,
                HasNext = offset + 1 >= maxCount,
                HasPrevious = page > 1
            });
        }

        [HttpPut("{videoId}/segment/{segment}")]
        [HttpPut("{videoId}/segment/last")]
        public IActionResult Push(System.Guid videoId, Microsoft.AspNetCore.Http.IFormFile file, string about, int segment = 0)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.First(e => e.Id == accountId);

            if (file == null)
            {
                file = Request.Form.Files.First();
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                file.CopyTo(memoryStream);

                if (segment > 0)
                {
                    videoFileManager.AddVideoFileContentSegment(videoId, segment, memoryStream.ToArray());
                }
                else
                {
                    var video = new Video
                    {
                        Id = videoId,
                        Thumbnail = new Thumbnail
                        {
                            About = string.Format("Thumbnail: {0}", about),
                            ContentType = "image/jpeg"
                        },
                        Extension = System.IO.Path.GetExtension(file.FileName),
                        About = about
                    };

                    videoFileManager.AddVideoFileContentSegmentAndClose(videoId, memoryStream.ToArray(), video.Extension);

                    try
                    {
                        using (var videoMediaFile = FFMediaToolkit.Decoding.MediaFile.Open(videoFileManager.GetVideoAbsoluteFilePath(video)))
                        {
                            var thumbnailFrame = videoMediaFile.Video.ReadFrame(videoMediaFile.Info.Duration / 3);

                            using (var thumbnailSkBitmap = SkiaSharp.SKBitmap.Decode(thumbnailFrame.Data))
                            {
                                using (var thumbnailSkImage = SkiaSharp.SKImage.FromBitmap(thumbnailSkBitmap))
                                {
                                    var thumbnailSkData = thumbnailSkImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75);

                                    thumbnailFileManager.SaveThumbnailFileContent(video.Thumbnail.Id, thumbnailSkData.ToArray(), "image/jpeg");
                                }
                            }

                            try
                            {
                                video.Thumbnail.Length = thumbnailFrame.Data.Length;

                                video.Length = videoMediaFile.Info.FileInfo.Length;
                                video.Duration = videoMediaFile.Info.Duration;
                                video.Format = videoMediaFile.Video.Info.CodecName;
                                video.FrameSize = string.Format("{0}x{1}", videoMediaFile.Video.Info.FrameSize.Width, videoMediaFile.Video.Info.FrameSize.Height);
                                video.Fps = videoMediaFile.Video.Info.AvgFrameRate;

                                dbContext.Videos.Add(video);

                                var accountVideoBridge = new Persistence.Entities.AccountVideoBridge
                                {
                                    AccountId = account.Id,
                                    VideoId = videoId
                                };

                                dbContext.AccountVideoBridges.Add(accountVideoBridge);

                                dbContext.SaveChanges(User.Identity.Name);
                            }
                            catch (System.Exception ex)
                            {
                                thumbnailFileManager.DeleteThumbnailFile(video.Thumbnail);

                                throw ex;
                            }
                        }                        
                    }
                    catch (System.Exception ex)
                    {
                        videoFileManager.DeleteVideoFile(videoId, video.Extension);

                        throw ex;
                    }
                }
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] VideoInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

                    var account = dbContext.Accounts.Include(e => e.VideoBridges).ThenInclude(b => b.Video).First(e => e.Id == accountId);

                    var entity = account.VideoBridges.First(b => b.VideoId == inputModel.Id).Video;

                    inputModel.Mergue(entity);

                    videoRepository.Update(entity, User.Identity.Name);

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

        [HttpDelete("{videoId}")]
        public ActionResult Delete(System.Guid videoId)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.Include(e => e.VideoBridges).ThenInclude(b => b.Video).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var bridge = account.VideoBridges.First(b => b.VideoId == videoId);

            dbContext.AccountVideoBridges.Remove(bridge);

            dbContext.Videos.Remove(bridge.Video);

            dbContext.Thumbnails.Remove(bridge.Video.Thumbnail);

            dbContext.SaveChanges(User.Identity.Name);

            videoFileManager.DeleteVideoFile(bridge.VideoId, bridge.Video.Extension);

            thumbnailFileManager.DeleteThumbnailFile(bridge.Video.Thumbnail);

            return Ok();
        }
    }
}
