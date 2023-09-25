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

        public AVProductionsController(IEntityRepository<AVCategory, int> categoryRepository, IEntityRepository<AVProduction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVProductionsController> localizer, ILogger<AVProductionsController> logger) : base(repository, localizer, logger)
        {
            this.categoryRepository = categoryRepository;
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
    }
}
