using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Helpers
{
    public class PlacardThumbnailViewProvisioningHelper : IPlacardThumbnailViewProvisioningHelperFacade
    {
        public PlacardThumbnailViewProvisioningHelper()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Dashboard.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardThumbnailViewProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.ContentView GetPlacardThumnailView(PlacardViewModel model)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardThumbnailViewProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetPlacardThumnailView(model);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
