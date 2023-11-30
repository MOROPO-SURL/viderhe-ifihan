using MOROPO.VIDERHE.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Providers
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
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying.Dashboard.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IOverlayDefaultSerializedContextProviderFacade).IsAssignableFrom(t));
        }

        public string GetOverlayDefaultContextModel(Extend.Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IOverlayDefaultSerializedContextProviderFacade>();

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
