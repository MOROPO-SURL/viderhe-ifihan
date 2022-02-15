using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Viderhe.Extend.Common.Transitioning.Presentation.Providers.Facade
{
    public interface ITransitionProviderFacade
    {
        Transitions.Contract.AbstractTransition GetFor(System.Guid transitionDescriptorId, BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback);

        Transitions.Contract.AbstractTransition GetRandom(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback);
    }
}
