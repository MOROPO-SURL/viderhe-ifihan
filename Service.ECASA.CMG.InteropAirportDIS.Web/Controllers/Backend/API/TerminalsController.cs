using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class TerminalsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Terminal, System.Guid, TerminalInputModel, TerminalDisplayModel>
    {
        public TerminalsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Terminal, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TerminalsController> localizer, ILogger<TerminalsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.TerminalViewerPermission)]
        public override ActionResult<TerminalDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.TerminalViewerPermission)]
        public override ActionResult<TerminalDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.TerminalViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<TerminalDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.TerminalCreatorPermission)]
        public override ActionResult Create([FromBody] TerminalInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.TerminalEditorPermission)]
        public override ActionResult Edit([FromBody] TerminalInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.TerminalRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }
    }
}
