using SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Extend.Common.Motion.Presentation.Providers.Facade
{
    public interface IMotionTransitionProviderFacade
    {
        Transitions.AbstractTransition GetFor(System.Guid transitionDescriptorId, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback);

        Transitions.AbstractTransition GetRandom(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback);
    }
}
