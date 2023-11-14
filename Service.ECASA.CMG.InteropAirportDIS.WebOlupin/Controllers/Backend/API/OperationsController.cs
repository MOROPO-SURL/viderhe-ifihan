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
    public class OperationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Operation, long, OperationInputModel, OperationDisplayModel>
    {
        public OperationsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Operation, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<OperationsController> localizer, ILogger<OperationsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.OperationViewerPermission)]
        public override ActionResult<OperationDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.OperationViewerPermission)]
        public override ActionResult<OperationDisplayModel> Get(long key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.OperationViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<OperationDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.OperationCreatorPermission)]
        public override ActionResult Create([FromBody] OperationInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.OperationEditorPermission)]
        public override ActionResult Edit([FromBody] OperationInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.OperationRemoverPermission)]
        public override ActionResult Delete(long key)
        {
            return base.Delete(key);
        }
    }
}
