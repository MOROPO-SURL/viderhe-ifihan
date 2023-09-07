using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class ApiKeysController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<ApiKey, System.Guid, ApiKeyInputModel, ApiKeyDisplayModel>
    {
        public ApiKeysController(IEntityRepository<ApiKey, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ApiKeysController> localizer, ILogger<ApiKeysController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.ApiKeyViewerPermission)]
        public override ActionResult<ApiKeyDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.ApiKeyViewerPermission)]
        public override ActionResult<PaginationModel<ApiKeyDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.ApiKeyViewerPermission)]
        public override ActionResult<ApiKeyDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.ApiKeyCreatorPermission)]
        public override ActionResult Create([FromBody] ApiKeyInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.ApiKeyEditorPermission)]
        public override ActionResult Edit([FromBody] ApiKeyInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.ApiKeyRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override void PreCreate(ApiKey entity, ApiKeyInputModel model)
        {
            base.PreCreate(entity, model);

            entity.RoleBridges = model.Roles.Select(item => new ApiKeyRoleBridge
            {
                Prow = entity,
                SternId = item.Id
            }).ToList();
        }

        protected override void PreEdit(ApiKey entity, ApiKeyInputModel model)
        {
            base.PreEdit(entity, model);

            entity.RoleBridges.Clear();

            entity.RoleBridges = model.Roles.Select(item => new ApiKeyRoleBridge
            {
                Prow = entity,
                SternId = item.Id
            }).ToList();
        }
    }
}
