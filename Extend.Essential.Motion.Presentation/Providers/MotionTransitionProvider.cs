using SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Motion.Presentation.Providers
{
    public class MotionTransitionProvider : Common.Motion.Presentation.Providers.Facade.IMotionTransitionProviderFacade
    {
        public Common.Motion.Presentation.Transitions.AbstractTransition GetFor(System.Guid transitionDescriptorId, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            if (transitionDescriptorId == Motion.Transitions.ScalingGrowFadeOutInTransitionDescriptor.ID)
            {
                return new Transitions.ScalingGrowFadeOutInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
            }

            // TODO Complete method implementation!!
            return null;
        }

        public Common.Motion.Presentation.Transitions.AbstractTransition GetRandom(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var randomizer = new System.Random();

            var randomTransitionIndex = randomizer.Next(0, 8);
            //var randomTransitionIndex = randomizer.Next(5, 7);

            switch (randomTransitionIndex)
            {
                case 0:
                    return Factories.RandomMotionTransitionFactory.CreateFlatSpectrumHandFanTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
                case 1:
                case 2:
                    var colors = new Xamarin.Forms.Color[]
                    {
                        Xamarin.Forms.Color.Accent,
                        Xamarin.Forms.Color.Black,
                        Xamarin.Forms.Color.White,
                        accountInformationProvider.PrimaryColor,
                        accountInformationProvider.SecoundaryColor
                    };

                    return Factories.RandomMotionTransitionFactory.CreateFlatBoxMatrixSweptTransition(colors[randomizer.Next(0, colors.Length)], incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
                case 4:
                case 5:
                    return Factories.RandomMotionTransitionFactory.CreateSimpleCarouselTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
                default:
                    return Factories.RandomMotionTransitionFactory.CreateFlatSpectrumInverseGothTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
            }

            throw new System.InvalidOperationException();
        }
    }
}
