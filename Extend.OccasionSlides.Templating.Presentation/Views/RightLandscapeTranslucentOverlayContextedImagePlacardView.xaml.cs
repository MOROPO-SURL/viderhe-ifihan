using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class RightLandscapeTranslucentOverlayContextedImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public RightLandscapeTranslucentOverlayContextedImagePlacardView(Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            FlyoutLayout.IsVisible = false;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContext = BindingContext as Models.View.LandscapeTranslucentOverlayContextedImagePlacardViewModel;

            FlyoutLayout.TranslationX = Width * (concreteBindingContext.OverlaySize.ToColumnCount() / 6d);

            FlyoutLayout.IsVisible = true;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000"
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = FlyoutLayout,
                TranslateX = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = "650"
            });

            internalShowInStoryboard.Begin();
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

            var columnWidth = eventArgs.Info.Width / System.Convert.ToDouble(concreteBindingContext.OverlaySize.ToColumnCount());

            var contentBoxWidth = columnWidth * (concreteBindingContext.OverlaySize.ToColumnCount() - 1);

            SkiaSharp.SKPath path;

            switch (concreteBindingContext.OverlayShapeKind)
            {
                case Enumerations.MediaContextOverlayShapeKind.TriangleFullTop:
                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {3} 0 h -{0} l {1} {2} H {3} z", contentBoxWidth + (columnWidth / 2), columnWidth / 2, eventArgs.Info.Height, eventArgs.Info.Width));

                    break;

                case Enumerations.MediaContextOverlayShapeKind.TriangleFullBottom:
                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {3} 0 h -{0} l -{1} {2} H {3} z", contentBoxWidth, columnWidth / 2, eventArgs.Info.Height, eventArgs.Info.Width));

                    break;

                case Enumerations.MediaContextOverlayShapeKind.Rectangle:
                default:
                    var spectedWidth = contentBoxWidth + Wrapper.Width / Providers.ConstantProvider.CONTEXT_OVERLAY_FLYOUT_PADDING_BY_WRAPPER_WIDTH_RAZON;

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {2} 0 h -{0} V {1} H {2} z", spectedWidth, eventArgs.Info.Height, eventArgs.Info.Width));

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