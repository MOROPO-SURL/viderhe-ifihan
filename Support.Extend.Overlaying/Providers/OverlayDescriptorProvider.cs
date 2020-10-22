using SmartSolucionesCuba.Videre.Extend.Common.Overlaying.Descriptors;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Extend.Overlaying.Providers
{
    public sealed class OverlayDescriptorProvider
    {
        private static OverlayDescriptorProvider instance;

        public static OverlayDescriptorProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverlayDescriptorProvider();
                }

                return instance;
            }
        }

        private OverlayDescriptorProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Videre.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Videre\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Overlaying,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IOverlayDescriptor).IsAssignableFrom(t));
        }

        public IOverlayDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<IOverlayDescriptor>();

            result.AddRange(XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IOverlayDescriptor>());

            return result.ToArray();
        }

        public IOverlayDescriptor GetDescriptorById(System.Guid id)
        {
            return GetDescriptors().FirstOrDefault(item => item.Id == id);
        }
    }
}
