namespace SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views
{
    public class BasePlacardPresentationView : XFToolKit.Mvvm.Views.ContentView
    {
        public virtual Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout { get; }

        public virtual void ConfigureLayout(Xamarin.Forms.View view) { }

        public virtual Xamarin.Forms.View PlacardView { get; }

        public event System.EventHandler PresentationComplete;

        public virtual void ShowInTransitionCompleteCallback() { }

        protected virtual void EndPresentation()
        {
            PresentationComplete?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
