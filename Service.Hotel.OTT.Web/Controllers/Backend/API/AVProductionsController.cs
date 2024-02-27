using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Web.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class AVProductionsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<AVProduction, System.Guid, AVProductionInputModel, AVProductionDisplayModel>
    {
        private readonly IEntityRepository<AVCategory, int> categoryRepository;
        private readonly IEntityRepository<Framework.Guama.Media.Persistence.Entities.Video, System.Guid> videoRepository;
        private readonly IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository;
        private readonly Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

        public AVProductionsController(Microsoft.Extensions.Configuration.IConfiguration configuration, Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager, IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository, IEntityRepository<Framework.Guama.Media.Persistence.Entities.Video, System.Guid> videoRepository, IEntityRepository<AVCategory, int> categoryRepository, IEntityRepository<AVProduction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVProductionsController> localizer, ILogger<AVProductionsController> logger) : base(repository, localizer, logger)
        {
            this.categoryRepository = categoryRepository;
            this.videoRepository = videoRepository;
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
            this.configuration = configuration;
        }

        [RequirePermissions(Authorization.AVProductionViewerPermission)]
        public override ActionResult<AVProductionDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.AVProductionViewerPermission)]
        public override ActionResult<AVProductionDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.AVProductionViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<AVProductionDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.AVProductionCreatorPermission)]
        public override ActionResult Create([FromBody] AVProductionInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.AVProductionEditorPermission)]
        public override ActionResult Edit([FromBody] AVProductionInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.AVProductionRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override AVProductionDisplayModel EntityToDisplayModel(AVProduction entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.ProducerHouses = entity.ProducerHouseBridges.Select(bridge =>
            {
                var _model = new AVProducerHouseDisplayModel();

                _model.Import(bridge.Stern);

                _model.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);

                return _model;
            }).ToArray();

            if (entity.CategoryId != null)
            {
                model.Category = new AVCategoryDisplayModel();

                model.Category.Import(entity.Category);

                if (entity.Category.ParentId != null)
                {
                    categoryRepository.Get(entity.Category.ParentId.Value).PopulateParent(model.Category, categoryRepository);
                }
            }

            if (model.PosterImage != null)
            {
                model.PosterImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.PosterImage.ContentType);
            }

            if (model.PlacardImage != null)
            {
                model.PlacardImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.PlacardImage.ContentType);
            }

            return model;
        }

        protected override void PreCreate(AVProduction entity, AVProductionInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.Genres)
            {
                entity.GenreBridges.Add(new AVProductionAVGenreBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }

            foreach (var _model in model.ProducerHouses)
            {
                entity.ProducerHouseBridges.Add(new AVProductionAVProducerHouseBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }

            foreach (var _model in model.Countries)
            {
                entity.CountryBridges.Add(new AVProductionCountryBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }
        }

        protected override void PreEdit(AVProduction entity, AVProductionInputModel model)
        {
            base.PreEdit(entity, model);

            entity.GenreBridges.Clear();
            entity.ProducerHouseBridges.Clear();
            entity.CountryBridges.Clear();

            foreach (var _model in model.Genres)
            {
                entity.GenreBridges.Add(new AVProductionAVGenreBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }

            foreach (var _model in model.ProducerHouses)
            {
                entity.ProducerHouseBridges.Add(new AVProductionAVProducerHouseBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }

            foreach (var _model in model.Countries)
            {
                entity.CountryBridges.Add(new AVProductionCountryBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Id
                });
            }
        }

        [RequirePermissions(Authorization.AVProductionEditorPermission)]
        [HttpPut("{key}/image/poster")]
        public ActionResult EditImagePoster(System.Guid key, [FromBody] ImageInputModel model)
        {
            try
            {
                var entity = Repository.Get(key);

                if (model.Content != null)
                {
                    using (var imageMemoryStream = new System.IO.MemoryStream(model.Content))
                    {
                        using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                        {
                            using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                            {
                                entity.PosterImage = imageRepository.Add(new Framework.Guama.Media.Persistence.Entities.Image
                                {
                                    ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.Extension),
                                    Length = model.Content.LongLength,
                                    Width = imageSkBitmap.Width,
                                    Height = imageSkBitmap.Height,
                                    About = string.Format("Image for production poster: {0}", key)
                                }, User.Identity.Name, false);
                                entity.PosterImageId = entity.PosterImage.Id;

                                imageFileManager.SaveImageFileContent(entity.PosterImage.Id, model.Content, entity.PosterImage.ContentType);
                            }
                        }
                    }
                }

                Repository.Update(entity, User.Identity.Name);

                if (model.Content != null && model.Id != null)
                {
                    var deprecatedImage = imageRepository.Get(model.Id.Value);

                    imageRepository.Delete(deprecatedImage, User.Identity.Name);

                    imageFileManager.DeleteImageFile(deprecatedImage);
                }

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }

        [RequirePermissions(Authorization.AVProductionEditorPermission)]
        [HttpPut("{key}/image/placard")]
        public ActionResult EditImagePlacard(System.Guid key, [FromBody] ImageInputModel model)
        {
            try
            {
                var entity = Repository.Get(key);

                if (model.Content != null)
                {
                    using (var imageMemoryStream = new System.IO.MemoryStream(model.Content))
                    {
                        using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                        {
                            using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                            {
                                entity.PlacardImage = imageRepository.Add(new Framework.Guama.Media.Persistence.Entities.Image
                                {
                                    ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.Extension),
                                    Length = model.Content.LongLength,
                                    Width = imageSkBitmap.Width,
                                    Height = imageSkBitmap.Height,
                                    About = string.Format("Image for production placard: {0}", key)
                                }, User.Identity.Name, false);
                                entity.PlacardImageId = entity.PlacardImage.Id;

                                imageFileManager.SaveImageFileContent(entity.PlacardImage.Id, model.Content, entity.PlacardImage.ContentType);
                            }
                        }
                    }
                }

                Repository.Update(entity, User.Identity.Name);

                if (model.Content != null && model.Id != null)
                {
                    var deprecatedImage = imageRepository.Get(model.Id.Value);

                    imageRepository.Delete(deprecatedImage, User.Identity.Name);

                    imageFileManager.DeleteImageFile(deprecatedImage);
                }

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }

        [RequirePermissions(Authorization.AVProductionEditorPermission)]
        [HttpPut("{key}/video/trailer/path")]
        public ActionResult EditVideoTrailerByPath(System.Guid key, string path)
        {
            try
            {
                var entity = Repository.Get(key);

                var newFileInfo = new System.IO.FileInfo(path);

                if (!newFileInfo.Exists) return NoContent();

                //var inputMediaFile = new MediaToolkit.Model.MediaFile(path);

                //mediaToolkitEngine.GetMetadata(inputMediaFile);

                var trailerVideo = new Framework.Guama.Media.Persistence.Entities.Video
                {
                    Length = newFileInfo.Length,
                    Extension = newFileInfo.Extension,
                    //Duration = inputMediaFile.Metadata.Duration,
                    //Fps = inputMediaFile.Metadata.VideoData.Fps,
                    //Format = inputMediaFile.Metadata.VideoData.Format,
                    //FrameSize = inputMediaFile.Metadata.VideoData.FrameSize,
                    //ColorModel = inputMediaFile.Metadata.VideoData.ColorModel,
                    //AudioFormat = inputMediaFile.Metadata.AudioData.Format,
                    //AudioChannelOutput = inputMediaFile.Metadata.AudioData.ChannelOutput
                };

                newFileInfo.MoveTo(System.IO.Path.Join(configuration["VIDERHE:VODRootPath"], string.Format("{0}.{1}", trailerVideo.Id, trailerVideo.Extension)));

                var deprecatedVideoId = entity.TrailerVideoId;
                var deprecatedVideoExtension = entity.TrailerVideo?.Extension;

                entity.TrailerVideo = videoRepository.Add(trailerVideo, User.Identity.Name, false);
                entity.TrailerVideoId = entity.TrailerVideo.Id;

                Repository.Update(entity, User.Identity.Name);

                if (deprecatedVideoId != null)
                {
                    var deprecatedFileInfo = new System.IO.FileInfo(System.IO.Path.Join(configuration["VIDERHE:VODRootPath"], string.Format("{0}.{1}", deprecatedVideoId, deprecatedVideoExtension)));

                    if (deprecatedFileInfo.Exists)
                    {
                        try
                        {
                            deprecatedFileInfo.Delete();
                        }
                        catch { }
                    }
                }

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }

        [RequirePermissions(Authorization.AVProductionEditorPermission)]
        [HttpPut("{key}/video/audiovisual/path")]
        public ActionResult EditVideoAudiovisualByPath(System.Guid key, string path)
        {
            try
            {
                var entity = Repository.Get(key);

                var newFileInfo = new System.IO.FileInfo(path);

                if (!newFileInfo.Exists) return NoContent();

                //var inputMediaFile = new MediaToolkit.Model.MediaFile(path);

                //mediaToolkitEngine.GetMetadata(inputMediaFile);

                var audiovisualVideo = new Framework.Guama.Media.Persistence.Entities.Video
                {
                    Length = newFileInfo.Length,
                    Extension = newFileInfo.Extension,
                    //Duration = inputMediaFile.Metadata.Duration,
                    //Fps = inputMediaFile.Metadata.VideoData.Fps,
                    //Format = inputMediaFile.Metadata.VideoData.Format,
                    //FrameSize = inputMediaFile.Metadata.VideoData.FrameSize,
                    //ColorModel = inputMediaFile.Metadata.VideoData.ColorModel,
                    //AudioFormat = inputMediaFile.Metadata.AudioData.Format,
                    //AudioChannelOutput = inputMediaFile.Metadata.AudioData.ChannelOutput
                };

                newFileInfo.MoveTo(System.IO.Path.Join(configuration["VIDERHE:VODRootPath"], string.Format("{0}.{1}", audiovisualVideo.Id, audiovisualVideo.Extension)));

                var deprecatedVideoId = entity.VideoId;
                var deprecatedVideoExtension = entity.Video?.Extension;

                entity.Video = videoRepository.Add(audiovisualVideo, User.Identity.Name, false);
                entity.VideoId = entity.Video.Id;

                Repository.Update(entity, User.Identity.Name);

                if (deprecatedVideoId != null)
                {
                    var deprecatedFileInfo = new System.IO.FileInfo(System.IO.Path.Join(configuration["VIDERHE:VODRootPath"], string.Format("{0}.{1}", deprecatedVideoId, deprecatedVideoExtension)));

                    if (deprecatedFileInfo.Exists)
                    {
                        try
                        {
                            deprecatedFileInfo.Delete();
                        }
                        catch { }
                    }
                }

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }
    }
}
