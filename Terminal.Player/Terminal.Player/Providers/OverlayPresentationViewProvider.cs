using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Player.Providers
{
    public sealed class OverlayPresentationViewProvider
    {
        private static OverlayPresentationViewProvider instance;

        public static OverlayPresentationViewProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayPresentationViewProvider();
                }

                return instance;
            }
        }

        private OverlayPresentationViewProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Extend.Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade).IsAssignableFrom(t));
        }

        public Extend.Common.Overlaying.Presentation.Views.BaseOverlayView GetOverlayPresentationView()
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(AccountInformationProvider.Instance);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
