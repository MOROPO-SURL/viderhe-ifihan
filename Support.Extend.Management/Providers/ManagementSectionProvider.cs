using SmartSolucionesCuba.Viderhe.Extend.Common.Management.Sections.Contract;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Extend.Management.Providers
{
    public sealed class ManagementSectionProvider
    {
        private static ManagementSectionProvider instance;

        public static ManagementSectionProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagementSectionProvider();
                }

                return instance;
            }
        }

        private ManagementSectionProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Management,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IManagementSection).IsAssignableFrom(t));
        }

        public IManagementSection[] GetAll()
        {
            var result = new System.Collections.Generic.List<IManagementSection>();

            result.AddRange(XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IManagementSection>());

            return result.ToArray();
        }
    }
}
