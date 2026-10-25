using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Models.Context;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Transitions
{
    public class ZoomInTransition : AbstractTransition
    {
        private ZoomInTransitionContextModel context;

        private AbstractAnimation factShowInAnimation;

        public ZoomInTransition(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, ZoomInTransitionContextModel context, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback) : base(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback)
        {
            this.context = context;
        }

        protected override AbstractAnimation FactShowInAnimation => factShowInAnimation;

        public override void GetReady(Xamarin.Forms.Layout<Xamarin.Forms.View> wrapper)
        {
            incomingPlacardPresentationView.Scale = 0;
        }

        protected override Storyboard CreateShowInMotionStoryboard()
        {
            var storyboard = new Storyboard();

            factShowInAnimation = new ScaleToAnimation
            {
                Target = incomingPlacardPresentationView,
                Scale = 1,
                EasingType = context.MotionEasingType
            };

            storyboard.Animations.Add(factShowInAnimation);

            return storyboard;
        }

        protected override void GarbageCollect()
        {
            factShowInAnimation = null;

            context = null;
        }
    }
}
