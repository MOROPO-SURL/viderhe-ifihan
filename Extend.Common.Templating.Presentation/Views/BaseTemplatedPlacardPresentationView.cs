namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Views
{
    public class BaseTemplatedPlacardPresentationView : Common.Presentation.Views.BasePlacardPresentationView
    {
        public virtual void StartShowInWhenReady(Motion.Presentation.Transitions.AbstractTransition transition)
        {
            transition.PerformMotion();
        }

        public sealed override void OnShowInTransitionComplete()
        {
            if ((BindingContext is Models.View.AbstractScreenTimedPlacardViewModel) && (BindingContext as Models.View.AbstractScreenTimedPlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            PerformPlacardStarup();

            if (!(BindingContext is Models.View.AbstractScreenTimedPlacardViewModel)) return;

            Xamarin.Forms.Device.StartTimer((BindingContext as Models.View.AbstractScreenTimedPlacardViewModel).ScreenPresentationTime, () =>
            {
                if (BindingContext != null)
                {
                    EndPresentation();
                }

                return true;
            });
        }

        public virtual void PerformPlacardStarup() { }
    }
}
