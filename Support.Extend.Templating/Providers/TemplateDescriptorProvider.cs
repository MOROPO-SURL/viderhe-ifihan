using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Templating.Providers
{
    public sealed class TemplateDescriptorProvider
    {
        private static TemplateDescriptorProvider instance;

        public static TemplateDescriptorProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemplateDescriptorProvider();
                }

                return instance;
            }
        }

        private TemplateDescriptorProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(ITemplateDescriptor).IsAssignableFrom(t));
        }

        public ITemplateDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<ITemplateDescriptor>();

            result.AddRange(SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<ITemplateDescriptor>());

            return result.ToArray();
        }

        public ITemplateDescriptor GetDescriptorById(System.Guid id)
        {
            var descriptors = GetDescriptors();

            return descriptors.FirstOrDefault(item => item.Id == id);
        }
    }
}
