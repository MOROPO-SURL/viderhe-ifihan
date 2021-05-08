using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionFactory
    {
        public static Transitions.SimpleCarouselTransition CreateSimpleCarouselTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.SimpleCarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateSimpleCarouselTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}
