using SmartSolucionesCuba.Videre.Extend.Common.Templating.Descriptors;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Extend.Templating.Providers
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
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Templating,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(ITemplateDescriptor).IsAssignableFrom(t));
        }

        public ITemplateDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<ITemplateDescriptor>();

            result.AddRange(XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<ITemplateDescriptor>());

            return result.ToArray();
        }

        public ITemplateDescriptor GetDescriptorById(System.Guid id)
        {
            var descriptors = GetDescriptors();

            return descriptors.FirstOrDefault(item => item.Id == id);
        }
    }
}
