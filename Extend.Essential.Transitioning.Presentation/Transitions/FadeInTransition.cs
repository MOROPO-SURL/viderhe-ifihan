using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Models.Context;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Transitions
{
    public class FadeInTransition : AbstractTransition
    {
        private const double MotionSize = 80;

        private FadeInTransitionContextModel context;

        private AbstractAnimation factShowInAnimation;

        public FadeInTransition(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, FadeInTransitionContextModel context, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback) : base(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback)
        {
            this.context = context;
        }

        protected override AbstractAnimation FactShowInAnimation => factShowInAnimation;

        public override void GetReady(Xamarin.Forms.Layout<Xamarin.Forms.View> wrapper)
        {
            incomingPlacardPresentationView.Opacity = 0;

            switch (context.MotionDirection)
            {
                case VerticalTransitionOrientation.FromTop:
                    incomingPlacardPresentationView.TranslationY = MotionSize * -1;

                    break;
                case VerticalTransitionOrientation.FromBottom:
                    incomingPlacardPresentationView.TranslationY = MotionSize;

                    break;
            }
        }

        protected override Storyboard CreateShowInMotionStoryboard()
        {
            var storyboard = new Storyboard();

            if (context.MotionDirection == VerticalTransitionOrientation.None)
            {
                factShowInAnimation = new FadeToAnimation
                {
                    Target = incomingPlacardPresentationView,
                    Opacity = 1
                };
            }
            else
            {
                factShowInAnimation = new FadeInAnimation
                {
                    Target = incomingPlacardPresentationView,
                    Direction = context.MotionDirection == VerticalTransitionOrientation.FromBottom ? SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up : SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down
                };
            }

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
