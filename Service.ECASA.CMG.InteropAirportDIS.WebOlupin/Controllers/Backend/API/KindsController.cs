using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class KindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Kind, OperationKind, KindInputModel, KindDisplayModel>
    {
        public KindsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Kind, OperationKind> repository, Microsoft.Extensions.Localization.IStringLocalizer<KindsController> localizer, ILogger<KindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.KindViewerPermission)]
        public override ActionResult<KindDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.KindViewerPermission)]
        public override ActionResult<KindDisplayModel> Get(OperationKind key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.KindViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<KindDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.KindCreatorPermission)]
        public override ActionResult Create([FromBody] KindInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.KindEditorPermission)]
        public override ActionResult Edit([FromBody] KindInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.KindRemoverPermission)]
        public override ActionResult Delete(OperationKind key)
        {
            return base.Delete(key);
        }
    }
}
