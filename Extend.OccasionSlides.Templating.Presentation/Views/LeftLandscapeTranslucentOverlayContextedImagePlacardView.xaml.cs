using SkiaSharp.Views.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class LeftLandscapeTranslucentOverlayContextedImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LeftLandscapeTranslucentOverlayContextedImagePlacardView(Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            FlyoutContentWrapLayout.BackgroundColor = (BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel).OverlayBackgroundColor.MultiplyAlpha(Providers.ConstantProvider.TRANSLUCED_OPACITY_LEVEL / 255d);
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

        private void FlyoutContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            SkiaSharp.SKPath path;

            switch (concreteBindingContext.OverlayShapeKind)
            {
                case Enumerations.MediaContextOverlayShapeKind.TriangleFullTop:
                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} L 0 {1} z", eventArgs.Info.Width / 2, eventArgs.Info.Height));

                    break;

                case Enumerations.MediaContextOverlayShapeKind.TriangleFullBottom:
                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 L {0} {1} H 0 z", eventArgs.Info.Width / 2, eventArgs.Info.Height));

                    break;

                case Enumerations.MediaContextOverlayShapeKind.Rectangle:
                default:
                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} V {1} H 0 z", Wrapper.Width / Providers.ConstantProvider.CONTEXT_OVERLAY_FLYOUT_PADDING_BY_WRAPPER_WIDTH_RAZON, eventArgs.Info.Height));

                    break;
            }

            var overlay = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel).OverlayBackgroundColor.ToSKColor().WithAlpha(Providers.ConstantProvider.TRANSLUCED_OPACITY_LEVEL)
            };
            
            eventArgs.Surface.Canvas.ClipPath(path);
            eventArgs.Surface.Canvas.DrawPaint(overlay);
        }
    }
}