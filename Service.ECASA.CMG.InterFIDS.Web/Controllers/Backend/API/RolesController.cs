using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class RolesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Role, System.Guid, RoleInputModel, RoleDisplayModel>
    {
        public RolesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Role, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<RolesController> localizer, ILogger<RolesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.RoleViewerPermission)]
        public override ActionResult<RoleDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.RoleViewerPermission)]
        public override ActionResult<RoleDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.RoleViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<RoleDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.RoleCreatorPermission)]
        public override ActionResult Create([FromBody] RoleInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.RoleEditorPermission)]
        public override ActionResult Edit([FromBody] RoleInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.RoleRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }
    }
}
