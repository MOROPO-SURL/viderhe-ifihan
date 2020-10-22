namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class SimplePicturePlacardView : Common.Presentation.Views.BasePlacardPresentationView
    {
        public SimplePicturePlacardView(Models.View.SimplePicturePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => DefaultImagen;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void ShowInTransitionCompleteCallback()
        {
            base.ShowInTransitionCompleteCallback();

            if ((BindingContext as Models.View.SimplePicturePlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            if ((BindingContext as Models.View.SimplePicturePlacardViewModel).ZoomingEnabled)
            {
                var animation = new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = this,
                    Scale = Scale == 0 ? 1.2 : 1,
                    Duration = (BindingContext as Models.View.SimplePicturePlacardViewModel).ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                animation.Begin();
            }

            Xamarin.Forms.Device.StartTimer((BindingContext as Models.View.SimplePicturePlacardViewModel).ScreenPresentationTime, () =>
            {
                EndPresentation();

                return true;
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            DefaultImagen.Source = null;
        }
    }
}