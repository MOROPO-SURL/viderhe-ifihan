using SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views;
using SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Providers.Facade;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Extend.Templating.Presentation.Providers
{
    public sealed class PlacardPresentationViewProvider
    {
        private static PlacardPresentationViewProvider instance;

        public static PlacardPresentationViewProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardPresentationViewProvider();
                }

                return instance;
            }
        }

        private PlacardPresentationViewProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardPresentationViewProviderFacade).IsAssignableFrom(t));
        }

        public BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardPresentationViewProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(model);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
