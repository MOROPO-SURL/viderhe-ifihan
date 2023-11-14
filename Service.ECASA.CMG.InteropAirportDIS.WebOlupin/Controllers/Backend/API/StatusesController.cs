using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class StatusesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Status, System.Guid, StatusInputModel, StatusDisplayModel>
    {
        public StatusesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Status, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<StatusesController> localizer, ILogger<StatusesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.StatusViewerPermission)]
        public override ActionResult<StatusDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.StatusViewerPermission)]
        public override ActionResult<StatusDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.StatusViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<StatusDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.StatusCreatorPermission)]
        public override ActionResult Create([FromBody] StatusInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.StatusEditorPermission)]
        public override ActionResult Edit([FromBody] StatusInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.StatusRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }
    }
}
