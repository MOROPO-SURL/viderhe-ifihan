using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.ORM.EF.Repositories;
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
        private readonly IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository;
        private readonly Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager;

        public AVProductionsController(Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager, IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository, IEntityRepository<AVCategory, int> categoryRepository, IEntityRepository<AVProduction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVProductionsController> localizer, ILogger<AVProductionsController> logger) : base(repository, localizer, logger)
        {
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
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
        [HttpPut("{key}/images")]
        public ActionResult EditImages(System.Guid key, [FromBody] AVProductionImagesInputModel model)
        {
            try
            {
                var entity = Repository.Get(key);

                if (model.PosterImageContent != null)
                {
                    using (var imageMemoryStream = new System.IO.MemoryStream(model.PosterImageContent))
                    {
                        using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                        {
                            using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                            {
                                entity.PosterImage = imageRepository.Add(new Framework.Guama.Media.Persistence.Entities.Image
                                {
                                    ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.PosterImageExtension),
                                    Length = model.PosterImageContent.LongLength,
                                    Width = imageSkBitmap.Width,
                                    Height = imageSkBitmap.Height,
                                    About = string.Format("Image for production poster: {0}", key)
                                }, User.Identity.Name, false);
                                entity.PosterImageId = entity.PosterImage.Id;

                                imageFileManager.SaveImageFileContent(entity.PosterImage.Id, model.PosterImageContent, entity.PosterImage.ContentType);
                            }
                        }
                    }
                }

                if (model.PlacardImageContent != null)
                {
                    using (var imageMemoryStream = new System.IO.MemoryStream(model.PlacardImageContent))
                    {
                        using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                        {
                            using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                            {
                                entity.PlacardImage = imageRepository.Add(new Framework.Guama.Media.Persistence.Entities.Image
                                {
                                    ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.PlacardImageExtension),
                                    Length = model.PlacardImageContent.LongLength,
                                    Width = imageSkBitmap.Width,
                                    Height = imageSkBitmap.Height,
                                    About = string.Format("Image for production placard: {0}", key)
                                }, User.Identity.Name, false);
                                entity.PlacardImageId = entity.PlacardImage.Id;

                                imageFileManager.SaveImageFileContent(entity.PlacardImage.Id, model.PlacardImageContent, entity.PlacardImage.ContentType);
                            }
                        }
                    }
                }

                Repository.Update(entity, User.Identity.Name);

                if (model.PosterImageContent != null && model.PosterImageId != null)
                {
                    var deprecatedImage = imageRepository.Get(model.PosterImageId.Value);

                    imageRepository.Delete(deprecatedImage, User.Identity.Name);

                    imageFileManager.DeleteImageFile(deprecatedImage);
                }

                if (model.PlacardImageContent != null && model.PlacardImageId != null)
                {
                    var deprecatedImage = imageRepository.Get(model.PlacardImageId.Value);

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
    }
}
