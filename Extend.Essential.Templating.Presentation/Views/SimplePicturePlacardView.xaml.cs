using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Views
{
    public partial class SimplePicturePlacardView : BaseTemplatedPlacardPresentationView
    {
        public SimplePicturePlacardView(Models.View.SimplePicturePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            if ((BindingContext as Models.View.SimplePicturePlacardViewModel).ZoomingEnabled)
            {
                var animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = this,
                    Scale = Scale == 0 ? 1.2 : 1,
                    Duration = (BindingContext as Models.View.SimplePicturePlacardViewModel).ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                animation.Begin();
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            DefaultImagen.Source = null;
        }
    }
}