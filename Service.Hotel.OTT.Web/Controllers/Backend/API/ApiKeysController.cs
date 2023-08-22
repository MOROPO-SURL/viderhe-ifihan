using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
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
        private readonly IEntityRepository<Permission, int> permissionRepository;

        public ApiKeysController(IEntityRepository<Permission, int> permissionRepository, IEntityRepository<ApiKey, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ApiKeysController> localizer, ILogger<ApiKeysController> logger) : base(repository, localizer, logger)
        {
            this.permissionRepository = permissionRepository;
        }

        [RequirePermissions(Constants.Permission.ApiKeyViewer)]
        public override ActionResult<ApiKeyDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Constants.Permission.ApiKeyViewer)]
        public override ActionResult<PaginationModel<ApiKeyDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Constants.Permission.ApiKeyViewer)]
        public override ActionResult<ApiKeyDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Constants.Permission.ApiKeyEditor)]
        public override ActionResult Create([FromBody] ApiKeyInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Constants.Permission.ApiKeyEditor)]
        public override ActionResult Edit([FromBody] ApiKeyInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Constants.Permission.ApiKeyRemover)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override ApiKeyDisplayModel EntityToDisplayModel(ApiKey entity)
        {
            var model = base.EntityToDisplayModel(entity);

            var permissionGroups = permissionRepository.FindBy(item => item.Family != null).GroupBy(item => item.Family).ToArray();

            model.GroupedPermissions = permissionGroups.Select(item => new System.Collections.Generic.KeyValuePair<string, Permission[]>
            (
                item.Key,
                item.ToArray()
            )).ToArray();

            return model;
        }

        protected override void PreCreate(ApiKey entity, ApiKeyInputModel model)
        {
            base.PreCreate(entity, model);

            entity.PermissionBridges = model.Permissions.Select(item => new ApiKeyPermissionBridge
            {
                Prow = entity,
                SternId = item.Id
            }).ToList();
        }

        protected override void PreEdit(ApiKey entity, ApiKeyInputModel model)
        {
            base.PreEdit(entity, model);

            entity.PermissionBridges.Clear();

            entity.PermissionBridges = model.Permissions.Select(item => new ApiKeyPermissionBridge
            {
                Prow = entity,
                SternId = item.Id
            }).ToList();
        }
    }
}
