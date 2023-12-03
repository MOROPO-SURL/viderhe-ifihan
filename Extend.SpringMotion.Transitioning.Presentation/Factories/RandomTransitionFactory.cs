using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Transitions;

namespace MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Factories
{
    public static class RandomTransitionFactory
    {
        public static FlatBoxMatrixSweptCurtainTransition CreateFlatBoxMatrixSweptCurtainTransition(Xamarin.Forms.Color color, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new FlatBoxMatrixSweptCurtainTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFlatBoxMatrixSweptCurtainTransitionContextModel(color), motionCompletedActionCallback);
        }

        public static FlatSpectrumHandFanTransition CreateFlatSpectrumHandFanTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new FlatSpectrumHandFanTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateBaseFlatSpectrumTransitionContextModel(), motionCompletedActionCallback);
        }

        public static FlatSpectrumReverseTrailTransition CreateFlatSpectrumInverseGothTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new FlatSpectrumReverseTrailTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFlatSpectrumInverseGothTransitionContextModel(), motionCompletedActionCallback);
        }

        public static FlatDualSpectrumHandFanCurtainTransition CreateFlatDualSpectrumHandFanCurtainTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new FlatDualSpectrumHandFanCurtainTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, RandomTransitionContextModelFactory.CreateFlatDualSpectrumHandFanCurtainTransitionContextModel(), motionCompletedActionCallback);
        }
    }
}