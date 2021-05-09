using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionFactory
    {
        public static Transitions.CarouselTransition CreateCarouselTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.CarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateCarouselTransitionContextModel(), motionCompletedActionCallback);
        }

        public static Transitions.ArriveTransition CreateArriveTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.ArriveTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateArriveTransitionContextModel(), motionCompletedActionCallback);
        }

        public static Transitions.FadeInTransition CreateFadeInTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FadeInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFadeInTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}
