using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Helpers.Provisioning
{
    public sealed class PlacardPresentationViewProvisioningHelper
    {
        private static PlacardPresentationViewProvisioningHelper instance;

        public static PlacardPresentationViewProvisioningHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardPresentationViewProvisioningHelper();
                }

                return instance;
            }
        }

        private PlacardPresentationViewProvisioningHelper()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardPresentationViewProviderFacade).IsAssignableFrom(t));
        }

        public VIDERHE.Extend.Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardPresentationViewProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
