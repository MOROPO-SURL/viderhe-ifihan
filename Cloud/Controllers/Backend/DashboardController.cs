using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade;
using MOROPO.VIDERHE.Cloud.Extensions;

namespace MOROPO.VIDERHE.Cloud.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    [Route("management/[controller]")]
    [Route("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/management/[controller]")]
    public class DashboardController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly System.Collections.Generic.IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;

        public DashboardController(System.Collections.Generic.IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders, Microsoft.Extensions.Localization.IStringLocalizer<DashboardController> localizer, ILogger<DashboardController> logger) : base(localizer, logger)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
        }

        public IActionResult Index()
        {
            return View(new Models.View.ManagementDashboardViewModel { Sections = managementDashboardSectionProviders.ToManagementDashboardSectionGroups() });
        }
    }
}
