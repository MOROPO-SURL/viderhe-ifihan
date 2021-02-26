using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Providers
{
    public sealed class OverlayDefaultSerializedContextProvider
    {
        private static OverlayDefaultSerializedContextProvider instance;

        public static OverlayDefaultSerializedContextProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayDefaultSerializedContextProvider();
                }

                return instance;
            }
        }

        private OverlayDefaultSerializedContextProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Viderhe.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying.Dashboard.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayDefaultSerializedContextProviderFacade).IsAssignableFrom(t));
        }

        public string GetOverlayDefaultContextModel(Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayDefaultSerializedContextProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetOverlayDefaultSerializedContext(overlayDescriptor, AccountInformationProvider.Instance);

                if (result == null) continue;

                return result;
            }

            // TODO Stash this change for acomplish at main branch!!
            return null;
        }
    }
}
