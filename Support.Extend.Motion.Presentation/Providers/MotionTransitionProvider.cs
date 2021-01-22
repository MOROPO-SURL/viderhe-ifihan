using SmartSolucionesCuba.Viderhe.Extend.Common.Motion.Presentation.Providers.Facade;
using SmartSolucionesCuba.Viderhe.Extend.Common.Motion.Presentation.Transitions;
using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Providers.Facade;
using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Extend.Motion.Presentation.Providers
{
    public class MotionTransitionProvider : IMotionTransitionProviderFacade
    {
        private static MotionTransitionProvider instance;

        public static MotionTransitionProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MotionTransitionProvider();
                }

                return instance;
            }
        }

        private MotionTransitionProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".Viderhe.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.Viderhe\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Motion.Presentation,\\sVersion=")).ToArray();

            XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(IMotionTransitionProviderFacade).IsAssignableFrom(t));
        }

        public AbstractTransition GetFor(System.Guid transitionDescriptorId, IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IMotionTransitionProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(transitionDescriptorId, accountInformationProvider, incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }

        public AbstractTransition GetRandom(IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var providers = XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<IMotionTransitionProviderFacade>();

            var randomizer = new System.Random();

            var randomProviderIndex = randomizer.Next(0, providers.Count());

            var provider = providers.ElementAt(randomProviderIndex);

            return provider.GetRandom(accountInformationProvider, incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
        }
    }
}
