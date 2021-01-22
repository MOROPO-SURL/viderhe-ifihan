using Microsoft.AspNetCore.Mvc;
using SmartSolucionesCuba.Viderhe.Cloud.Extensions;

namespace SmartSolucionesCuba.Viderhe.Cloud.Components
{
    public class DashboardSidebarViewComponent : ViewComponent
    {
        private readonly System.Collections.Generic.IEnumerable<SAPRESSC.Core.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;

        public DashboardSidebarViewComponent(System.Collections.Generic.IEnumerable<SAPRESSC.Core.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
        }

        public IViewComponentResult Invoke()
        {
            return View(managementDashboardSectionProviders.ToManagementDashboardSectionGroups());
        }
    }
}
