using SmartSolucionesCuba.Viderhe.Extend.Common.Management.Dashboard.Presentation.Providers.Facade;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Extend.Management.Presentation.Helpers.Provisioning
{
    public sealed class ManagementSectionProvisioningHelper
    {
        private static ManagementSectionProvisioningHelper instance;

        public static ManagementSectionProvisioningHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagementSectionProvisioningHelper();
                }

                return instance;
            }
        }

        private ManagementSectionProvisioningHelper()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Management.Dashboard.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IManageSectionPageProviderFacade).IsAssignableFrom(t));
        }

        public Xamarin.Forms.Page GetFor(Viderhe.Extend.Common.Management.Sections.Contract.IManagementSection section)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IManageSectionPageProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetManagementPageBySection(section);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }
    }
}
