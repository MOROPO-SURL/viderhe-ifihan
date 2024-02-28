namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Providers
{
    public class InfinityVideoTransitionProvider : Common.Transitioning.Presentation.Providers.Facade.ITransitionProviderFacade
    {
        public Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition GetFor(System.Guid transitionDescriptorId, Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return null;
        }

        public Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition GetRandom(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return null;
        }
    }
}
