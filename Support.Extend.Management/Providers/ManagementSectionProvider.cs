using MOROPO.VIDERHE.Extend.Common.Management.Sections.Contract;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Management.Providers
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
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Management,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IManagementSection).IsAssignableFrom(t));
        }

        public IManagementSection[] GetAll()
        {
            var result = new System.Collections.Generic.List<IManagementSection>();

            result.AddRange(SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IManagementSection>());

            return result.ToArray();
        }
    }
}
