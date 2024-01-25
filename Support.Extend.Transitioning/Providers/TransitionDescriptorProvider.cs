using MOROPO.VIDERHE.Extend.Common.Transitioning.Descriptors;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Extend.Transitioning.Providers
{
    public sealed class TransitionDescriptorProvider
    {
        private static TransitionDescriptorProvider instance;

        public static TransitionDescriptorProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransitionDescriptorProvider();
                }

                return instance;
            }
        }

        private TransitionDescriptorProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Transitioning,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(ITransitionDescriptor).IsAssignableFrom(t));
        }

        public ITransitionDescriptor[] GetDescriptors()
        {
            var result = new System.Collections.Generic.List<ITransitionDescriptor>();

            result.AddRange(SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<ITransitionDescriptor>());

            return result.ToArray();
        }

        public ITransitionDescriptor GetDescriptorById(System.Guid id)
        {
            return GetDescriptors().FirstOrDefault(item => item.Id == id);
        }
    }
}
