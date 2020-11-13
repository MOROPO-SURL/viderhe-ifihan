using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Providers
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
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying.Dashboard.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, System.Action<string> successfulCompleteCallbackAction)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetConfigurationPageByDescriptor(overlayDescriptor, serializedContext, successfulCompleteCallbackAction);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
