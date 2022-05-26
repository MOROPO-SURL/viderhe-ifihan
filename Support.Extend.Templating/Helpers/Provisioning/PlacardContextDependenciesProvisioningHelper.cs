using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Extend.Templating.Helpers.Provisioning
{
    public sealed class PlacardContextDependenciesProvisioningHelper
    {
        private static PlacardContextDependenciesProvisioningHelper instance;

        public static PlacardContextDependenciesProvisioningHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacardContextDependenciesProvisioningHelper();
                }

                return instance;
            }
        }

        private PlacardContextDependenciesProvisioningHelper()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(Viderhe.Extend.Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider).IsAssignableFrom(t));
        }

        public Viderhe.Extend.Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Viderhe.Extend.Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetImages(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }

        public Viderhe.Extend.Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<Viderhe.Extend.Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetVideos(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }
    }
}
