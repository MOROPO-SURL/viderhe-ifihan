using System.Linq;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Common.Presentation.Views;

namespace MOROPO.VIDERHE.Support.Extend.Transitioning.Presentation.Providers
{
    public class TransitionProvider : ITransitionProviderFacade
    {
        private static TransitionProvider instance;

        public static TransitionProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransitionProvider();
                }

                return instance;
            }
        }

        private TransitionProvider()
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.FullName.Contains(".VIDERHE.Support.Extend") && System.Text.RegularExpressions.Regex.IsMatch(a.FullName, ".+\\.VIDERHE\\.Extend\\.[a-zA-Z0-9|\\.]+\\.Transitioning.Presentation,\\sVersion=")).ToArray();

            SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.AutoRegister(assemblies, SmartSolucionesCuba.XFToolKit.IoC.DuplicateImplementationActions.RegisterMultiple, t => typeof(ITransitionProviderFacade).IsAssignableFrom(t));
        }

        public AbstractTransition GetFor(System.Guid transitionDescriptorId, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<ITransitionProviderFacade>();

            foreach (var provider in providers)
            {
                var result = provider.GetFor(transitionDescriptorId, incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                if (result == null) continue;

                return result;
            }

            throw new System.InvalidOperationException();
        }

        public AbstractTransition GetRandom(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var providers = SmartSolucionesCuba.XFToolKit.IoC.TinyIoCContainer.Current.ResolveAll<ITransitionProviderFacade>();

            var randomizer = new System.Random();

            var randomProviderIndex = randomizer.Next(0, providers.Count());

            var provider = providers.ElementAt(randomProviderIndex);

            return provider.GetRandom(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
        }
    }
}
