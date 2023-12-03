using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Transitions;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionFactory
    {
        public static CarouselTransition CreateCarouselTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new CarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateCarouselTransitionContextModel(), motionCompletedActionCallback);
        }

        public static ArriveTransition CreateArriveTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new ArriveTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateArriveTransitionContextModel(), motionCompletedActionCallback);
        }

        public static FadeInTransition CreateFadeInTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new FadeInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFadeInTransitionContextModel(), motionCompletedActionCallback);
        }

        public static ZoomInTransition CreateZoomInTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new ZoomInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateZoomInTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}
