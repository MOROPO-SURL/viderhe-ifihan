using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomMotionTransitionFactory
    {
        public static Transitions.FlatBoxMatrixSweptTransition CreateFlatBoxMatrixSweptTransition(Xamarin.Forms.Color color, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatBoxMatrixSweptTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomMotionTransitionContextModelFactory.CreateFlatBoxMatrixSweptTransitionContextModel(color), motionCompletedActionCallback);
        }

        public static Transitions.FlatSpectrumHandFanTransition CreateFlatSpectrumHandFanTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatSpectrumHandFanTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomMotionTransitionContextModelFactory.CreateBaseFlatSpectrumTransitionContextModel(), motionCompletedActionCallback);
        }

        public static Transitions.FlatSpectrumReverseTrailTransition CreateFlatSpectrumInverseGothTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatSpectrumReverseTrailTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomMotionTransitionContextModelFactory.CreateFlatSpectrumInverseGothTransitionContextModel(), motionCompletedActionCallback);
        }

        public static Transitions.SimpleCarouselTransition CreateSimpleCarouselTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.SimpleCarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomMotionTransitionContextModelFactory.CreateSimpleCarouselTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}
