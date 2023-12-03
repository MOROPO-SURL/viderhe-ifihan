using MOROPO.VIDERHE.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Providers
{
    public sealed class OverlayConfigurationPageProvider
    {
        private static OverlayConfigurationPageProvider instance;

        public static OverlayConfigurationPageProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayConfigurationPageProvider();
                }

                return instance;
            }
        }

        private OverlayConfigurationPageProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying.Dashboard.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IOverlayConfigurationPageProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IOverlayConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetConfigurationPageByDescriptor(overlayDescriptor, serializedContext, successfulCompleteCallbackAction);

                if (result == null) continue;

                return result;
            }

            // TODO Stash this change for acomplish at main branch!!
            return null;
        }
    }
}
