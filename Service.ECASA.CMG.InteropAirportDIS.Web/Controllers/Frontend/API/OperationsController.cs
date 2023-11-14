using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Controllers.Frontend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/frontend/[controller]")]
    [ApiController]
    public class OperationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiConsultFilteredController<Operation, long, OperationDisplayModel, OperationFilterModel>
    {
        public OperationsController(IEntityRepository<Operation, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<OperationsController> localizer, ILogger<OperationsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
