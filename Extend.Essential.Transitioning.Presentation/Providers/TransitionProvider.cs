using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Factories;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Providers
{
    public class TransitionProvider : ITransitionProviderFacade
    {
        public AbstractTransition GetFor(System.Guid transitionDescriptorId, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            // TODO Complete method implementation!!
            return null;
        }

        public AbstractTransition GetRandom(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var randomizer = new System.Random();

            var randomTransitionIndex = randomizer.Next(0, 6);

            switch (randomTransitionIndex)
            {
                case 0:
                    return RandomTransitionFactory.CreateFadeInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                case 1:
                case 2:
                    return RandomTransitionFactory.CreateArriveTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                case 3:
                case 4:
                    return RandomTransitionFactory.CreateCarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                case 5:
                default:
                    return RandomTransitionFactory.CreateZoomInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
            }

            throw new System.InvalidOperationException();
        }
    }
}
