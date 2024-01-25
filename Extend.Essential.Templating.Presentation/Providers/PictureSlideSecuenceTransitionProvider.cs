using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Providers
{
    public class PictureSlideSecuenceTransitionProvider : ITransitionProviderFacade
    {
        public AbstractTransition GetFor(System.Guid transitionDescriptorId, Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback)
        {
            if (transitionDescriptorId == Transitioning.Transitions.ScalingGrowFadeOutInTransitionDescriptor.ID)
            {
                return new Transitioning.Presentation.Transitions.ScalingGrowFadeOutInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
            }

            // TODO Complete method implementation!!
            return null;
        }

        public AbstractTransition GetRandom(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback)
        {
            return new Transitioning.Presentation.Transitions.ScalingGrowFadeOutInTransition(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback);
        }
    }
}
