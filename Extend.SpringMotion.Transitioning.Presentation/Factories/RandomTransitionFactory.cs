using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.SpringMotion.Transitioning.Presentation.Factories
{
    public static class RandomTransitionFactory
    {
        public static Transitions.FlatBoxMatrixSweptTransition CreateFlatBoxMatrixSweptTransition(Xamarin.Forms.Color color, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatBoxMatrixSweptTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFlatBoxMatrixSweptTransitionContextModel(color), motionCompletedActionCallback);
        }

        public static Transitions.FlatSpectrumHandFanTransition CreateFlatSpectrumHandFanTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatSpectrumHandFanTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateBaseFlatSpectrumTransitionContextModel(), motionCompletedActionCallback);
        }

        public static Transitions.FlatSpectrumReverseTrailTransition CreateFlatSpectrumInverseGothTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitions.FlatSpectrumReverseTrailTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFlatSpectrumInverseGothTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}
