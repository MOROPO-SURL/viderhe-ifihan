using SmartSolucionesCuba.Videre.Extend.Common.Descriptors;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Extend.Providers
{
    public sealed class ExtensionDescriptorProvider
    {
        private static ExtensionDescriptorProvider instance;

        public static ExtensionDescriptorProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExtensionDescriptorProvider();
                }

                return instance;
            }
        }

        private ExtensionDescriptorProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IExtensionDescriptor).IsAssignableFrom(t));
        }

        public IExtensionDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<IExtensionDescriptor>();

            result.AddRange(XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IExtensionDescriptor>());

            return result.ToArray();
        }

        public IExtensionDescriptor GetDescriptorById(System.Guid id)
        {
            return GetDescriptors().FirstOrDefault(item => item.Id == id);
        }
    }
}
