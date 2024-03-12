using MOROPO.VIDERHE.Extend.Common.Presentation.Views;

namespace MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Transitions.Contract
{
    public abstract class AbstractTransition
    {
        protected readonly BasePlacardPresentationView incomingPlacardPresentationView;
        protected readonly BasePlacardPresentationView outgoingPlacardPresentationView;

        private System.Action<BasePlacardPresentationView> motionCompletedActionCallback;

        protected AbstractTransition(BasePlacardPresentationView incomingPlacardPresentationView, BasePlacardPresentationView outgoingPlacardPresentationView, System.Action<BasePlacardPresentationView> motionCompletedActionCallback)
        {
            this.incomingPlacardPresentationView = incomingPlacardPresentationView;
            this.outgoingPlacardPresentationView = outgoingPlacardPresentationView;
            this.motionCompletedActionCallback = motionCompletedActionCallback;
        }

        public abstract void GetReady(Xamarin.Forms.Layout<Xamarin.Forms.View> wrapper);

        protected abstract void GarbageCollect();

        protected abstract SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard CreateShowInMotionStoryboard();

        protected abstract SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract.AbstractAnimation FactShowInAnimation { get; }

        public void PerformMotion()
        {
            var storyboard = CreateShowInMotionStoryboard();

            FactShowInAnimation.Completed += MotionStoryboard_Completed;

            storyboard.Begin();
        }

        private void MotionStoryboard_Completed(object sender, System.EventArgs eventArgs)
        {
            var factShowInAnimation = sender as SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract.AbstractAnimation;

            factShowInAnimation.Completed -= MotionStoryboard_Completed;

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                GarbageCollect();

                motionCompletedActionCallback?.Invoke(incomingPlacardPresentationView);

                motionCompletedActionCallback = null;
            });
        }
    }
}
