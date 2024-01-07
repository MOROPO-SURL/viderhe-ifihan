using MOROPO.VIDERHE.Extend.Common.Presentation.Views;

namespace MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Providers
{
    public class TransitionProvider : Common.Transitioning.Presentation.Providers.Facade.ITransitionProviderFacade
    {
        public Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition GetFor(System.Guid transitionDescriptorId, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            // TODO Complete method implementation!!
            return null;
        }

        public Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition GetRandom(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            var randomizer = new System.Random();

            var randomTransitionIndex = randomizer.Next(0, 10);

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            switch (randomTransitionIndex)
            {
                case 0:
                case 1:
                case 2:
                    return Factories.RandomTransitionFactory.CreateFlatSpectrumHandFanTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                case 3:
                    var colors = new Xamarin.Forms.Color[]
                    {
                        Xamarin.Forms.Color.Black,
                        Xamarin.Forms.Color.White,
                        accountInformationProvider.PrimaryColor,
                        accountInformationProvider.SecoundaryColor
                    };

                    return Factories.RandomTransitionFactory.CreateFlatBoxMatrixSweptCurtainTransition(colors[randomizer.Next(0, colors.Length)], incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                case 4:
                case 5:
                case 6:
                    return Factories.RandomTransitionFactory.CreateFlatSpectrumInverseGothTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);

                default:
                    return Factories.RandomTransitionFactory.CreateFlatDualSpectrumHandFanCurtainTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
            }
        }
    }
}
