namespace SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views
{
    public class BasePlacardPresentationView : XFToolKit.Mvvm.Views.ContentView
    {
        public virtual Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout { get; }

        public virtual void ConfigureLayout(Xamarin.Forms.View view) { }

        public virtual Xamarin.Forms.View PlacardView { get; private set; }

        public event System.EventHandler PresentationComplete;

        public virtual void OnShowInTransitionComplete() { }

        protected virtual void EndPresentation()
        {
            PresentationComplete?.Invoke(this, System.EventArgs.Empty);
        }

        protected override void DisposeManagementResources()
        {
            base.DisposeManagementResources();

            if (PlacardView is System.IDisposable)
            {
                (PlacardView as System.IDisposable).Dispose();
            }

            PlacardView = null;
        }
    }
}