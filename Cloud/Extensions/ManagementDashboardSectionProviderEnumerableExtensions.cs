using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Collections.Generic;

namespace MOROPO.VIDERHE.Cloud.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySections = new List<ManagementDashboardSectionViewModel>();
            var serviceSections = new List<ManagementDashboardSectionViewModel>();
            var cloudSections = new List<ManagementDashboardSectionViewModel>();

            foreach (var provider in self)
            {
                if (provider is Framework.Guama.Security.Essential.Presentation.Web.Backend.Providers.ManagementDashboardSectionProvider)
                {
                    securitySections.AddRange(provider.GetManagementDashboardSections());
                }
            }

            securitySections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Registros",
                Controller = "traces",
                Action = "index",
                Area = "business",
                Role = Permission.TraceViewer
            });

            serviceSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cuentas",
                Controller = "accounts",
                Action = "index",
                Area = "business",
                Role = Permission.AccountViewer
            });

            serviceSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Platillas",
                Controller = "templates",
                Action = "index",
                Area = "business",
                Role = Permission.TraceViewer
            });

            serviceSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Transiciones",
                Controller = "transitions",
                Action = "index",
                Area = "business",
                Role = Permission.TraceViewer
            });

            cloudSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Reproductores",
                Controller = "players",
                Action = "index",
                Area = "business",
                Role = Permission.TraceViewer
            });

            cloudSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Imágenes",
                Controller = "images",
                Action = "index",
                Area = "media",
                Role = Permission.TraceViewer
            });

            cloudSections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Videos",
                Controller = "videos",
                Action = "index",
                Area = "media",
                Role = Permission.TraceViewer
            });

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySections },
                { "Servicio", serviceSections },
                { "Nube", cloudSections }
            };
        }
    }
}
