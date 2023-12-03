using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Transitions
{
    public class CarouselTransition : AbstractTransition
    {
        private Models.Context.CarouselTransitionContextModel context;

        private AbstractAnimation factShowInAnimation;

        public CarouselTransition(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, Models.Context.CarouselTransitionContextModel context, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback) : base(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback)
        {
            this.context = context;
        }

        protected override AbstractAnimation FactShowInAnimation => factShowInAnimation;

        public override void GetReady(Xamarin.Forms.Layout<Xamarin.Forms.View> wrapper)
        {
            switch (context.Direction)
            {
                case StandardTransitionDirection.LeftToRight:
                    incomingPlacardPresentationView.TranslationX = wrapper.Width * -1;

                    break;
                case StandardTransitionDirection.RightToLeft:
                    incomingPlacardPresentationView.TranslationX = wrapper.Width;

                    break;
                case StandardTransitionDirection.TopToBottom:
                    incomingPlacardPresentationView.TranslationY = wrapper.Height * -1;

                    break;
                case StandardTransitionDirection.BottomToTop:
                default:
                    incomingPlacardPresentationView.TranslationY = wrapper.Height;

                    break;
            }
        }

        protected override Storyboard CreateShowInMotionStoryboard()
        {
            var storyboard = new Storyboard
            {
                IsParallel = true
            };

            factShowInAnimation = new TranslateToAnimation
            {
                Target = incomingPlacardPresentationView,
                EasingType = context.MotionEasingType,
                TranslateX = 0,
                TranslateY = 0
            };

            if (outgoingPlacardPresentationView != null)
            {
                storyboard.Animations.Add(new TranslateToAnimation
                {
                    Target = outgoingPlacardPresentationView,
                    EasingType = context.MotionEasingType,
                    TranslateX = incomingPlacardPresentationView.TranslationX * -1,
                    TranslateY = incomingPlacardPresentationView.TranslationY * -1
                });
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
