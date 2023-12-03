using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Templating.Helpers.Provisioning
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
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IPlacardContextDependenciesProvider).IsAssignableFrom(t));
        }

        public ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetImages(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }

        public VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetVideos(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }

        public GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetGradients(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }

        public SoundContextModel[] GetSounds(System.Guid templateId, string serializedContext)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IPlacardContextDependenciesProvider>();

            foreach (var provider in providers)
            {
                var result = provider.GetSounds(templateId, serializedContext);

                if (result == null) continue;

                return result;
            }

            return null;
        }
    }
}
