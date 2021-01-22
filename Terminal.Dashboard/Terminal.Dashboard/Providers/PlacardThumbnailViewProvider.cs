using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Providers
{
    public sealed class PlacardThumbnailViewProvider
    {
        private static PlacardThumbnailViewProvider instance;

        public static PlacardThumbnailViewProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardThumbnailViewProvider();
                }

                return instance;
            }
        }

        private PlacardThumbnailViewProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Viderhe.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Dashboard.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Extend.Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Extend.Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetPlacardThumnailView(model, cloudServerProvider);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
