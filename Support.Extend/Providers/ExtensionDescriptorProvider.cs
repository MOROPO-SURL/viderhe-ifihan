using MOROPO.VIDERHE.Extend.Common.Descriptors;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Providers
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
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IExtensionDescriptor).IsAssignableFrom(t));
        }

        public IExtensionDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<IExtensionDescriptor>();

            result.AddRange(SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IExtensionDescriptor>());

            return result.ToArray();
        }

        public IExtensionDescriptor GetDescriptorById(System.Guid id)
        {
            return GetDescriptors().FirstOrDefault(item => item.Id == id);
        }
    }
}
