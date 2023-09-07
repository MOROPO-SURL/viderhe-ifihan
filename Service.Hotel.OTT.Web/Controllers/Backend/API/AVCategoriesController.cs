using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Web.Extensions;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class AVCategoriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<AVCategory, int, AVCategoryInputModel, AVCategoryDisplayModel>
    {
        public AVCategoriesController(IEntityRepository<AVCategory, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVCategoriesController> localizer, ILogger<AVCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.AVCategoryViewerPermission)]
        public override ActionResult<AVCategoryDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.AVCategoryViewerPermission)]
        public override ActionResult<AVCategoryDisplayModel> Get(int key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.AVCategoryViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<AVCategoryDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.AVCategoryCreatorPermission)]
        public override ActionResult Create([FromBody] AVCategoryInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.AVCategoryEditorPermission)]
        public override ActionResult Edit([FromBody] AVCategoryInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.AVCategoryRemoverPermission)]
        public override ActionResult Delete(int key)
        {
            return base.Delete(key);
        }

        protected override AVCategoryDisplayModel EntityToDisplayModel(AVCategory entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.ParentId != null)
            {
                Repository.Get(entity.ParentId.Value).PopulateParent(model, Repository);
            }

            return model;
        }

        protected override void PreCreate(AVCategory entity, AVCategoryInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.ParentId != null)
            {
                entity.Parent = Repository.Get(model.ParentId.Value);
                entity.ParentId = model.ParentId;
            }
        }

        protected override void PreEdit(AVCategory entity, AVCategoryInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ParentId != entity.ParentId)
            {
                if (model.ParentId != null)
                {
                    entity.Parent = Repository.Get(model.ParentId.Value);
                    entity.ParentId = model.ParentId;
                }
                else
                {
                    entity.Parent = null;
                    entity.ParentId = null;
                }
            }
        }
    }
}
