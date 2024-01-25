using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Helpers.Provisioning
{
    public sealed class EmbeddedFontFamilyNamesProvisioningHelper
    {
        private static EmbeddedFontFamilyNamesProvisioningHelper instance;

        public static EmbeddedFontFamilyNamesProvisioningHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmbeddedFontFamilyNamesProvisioningHelper();
                }

                return instance;
            }
        }

        private EmbeddedFontFamilyNamesProvisioningHelper()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IEmbeddedFontFamilyNamesProviderFacade).IsAssignableFrom(t));
        }

        public string[] GetAll()
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IEmbeddedFontFamilyNamesProviderFacade>();

            var list = new System.Collections.Generic.List<string>();

            foreach (var provider in providers)
            {
                var array = provider.GetAll();

                if (array == null) continue;

                list.AddRange(array);
            }

            return list.OrderBy(item => item).ToArray();
        }
    }
}
