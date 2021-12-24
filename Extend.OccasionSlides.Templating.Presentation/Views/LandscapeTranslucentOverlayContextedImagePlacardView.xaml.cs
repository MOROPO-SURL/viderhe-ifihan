using SkiaSharp.Views.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class LandscapeTranslucentOverlayContextedImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapeTranslucentOverlayContextedImagePlacardView(Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            DrawlerContentWrapLayout.BackgroundColor = (BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel).OverlayBackgroundColor.MultiplyAlpha(200 / 255);
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImagen.Source = null;
        }

        private void DrawlerEdgeSKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs eventArgs)
        {
            var path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} V {1} L 0 {2} z", eventArgs.Info.Height / 2, eventArgs.Info.Height, (int)(eventArgs.Info.Height * 0.75)));

            var overlay = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel).OverlayBackgroundColor.ToSKColor().WithAlpha(200)
            };

            eventArgs.Surface.Canvas.Clear();
            eventArgs.Surface.Canvas.ClipPath(path);
            eventArgs.Surface.Canvas.DrawPaint(overlay);
        }
    }
}