using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Providers
{
    public sealed class PlacardViewModelCompletitionHelperProvider
    {
        private static PlacardViewModelCompletitionHelperProvider instance;

        public static PlacardViewModelCompletitionHelperProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardViewModelCompletitionHelperProvider();
                }

                return instance;
            }
        }

        private PlacardViewModelCompletitionHelperProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardViewModelCompletitionHelperProviderFacade).IsAssignableFrom(t));
        }

        public IPlacardViewModelCompletitionHelperFacade GetFor(PlacardDisplayModel model)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardViewModelCompletitionHelperProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(model);

                if (result == null) continue;

                return result;
            }

            return null;
        }
    }
}
