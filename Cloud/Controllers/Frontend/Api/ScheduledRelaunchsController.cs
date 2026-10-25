using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    public class ScheduledRelaunchsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementFilteredController<ScheduledRelaunch, System.Guid, ScheduledRelaunchInputModel, ScheduledRelaunchDisplayModel, ScheduledRelaunchFilterModel>
    {
        public ScheduledRelaunchsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ScheduledRelaunch, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScheduledRelaunchsController> localizer, ILogger<ScheduledRelaunchsController> logger) : base(repository, localizer, logger)
        {
        }
    }
}
