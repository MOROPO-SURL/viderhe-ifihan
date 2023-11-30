using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Providers
{
    public sealed class PlacardConfigurationPageProvider
    {
        private static PlacardConfigurationPageProvider instance;

        public static PlacardConfigurationPageProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardConfigurationPageProvider();
                }

                return instance;
            }
        }

        private PlacardConfigurationPageProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Dashboard.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardConfigurationPageProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetCreationEntryPointPageByDescriptor(templateDescriptor, completedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetEditionPageByDescriptor(placardViewModel, completedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
