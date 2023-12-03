using Microsoft.AspNetCore.Mvc;
using MOROPO.VIDERHE.Cloud.Extensions;

namespace MOROPO.VIDERHE.Cloud.Components
{
    public class DashboardSidebarViewComponent : ViewComponent
    {
        private readonly System.Collections.Generic.IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> providers;

        public DashboardSidebarViewComponent(System.Collections.Generic.IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> providers)
        {
            this.providers = providers;
        }

        public IViewComponentResult Invoke()
        {
            return View(providers.ToManagementDashboardSectionGroups());
        }
    }
}
