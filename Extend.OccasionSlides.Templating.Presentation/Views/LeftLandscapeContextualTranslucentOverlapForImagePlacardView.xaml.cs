using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class LeftLandscapeContextualTranslucentOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LeftLandscapeContextualTranslucentOverlapForImagePlacardView(Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            OverlapLayout.IsVisible = false;
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel;

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d) * -1;

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = OverlapLayout,
                TranslateX = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = TitleLabel,
                Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                RelativeOffset = 100d,
                Delay = overlapShowInAnimationDuration.ToString(),
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = infoBlockShoInAnimationDuration.ToString()
            });

            var index = 1;

            foreach (var infoBlockLayout in InfoBlocksLayout.Children)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Target = infoBlockLayout,
                    Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImagen.Source = null;
        }

        private void OverlapContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var columnWidth = eventArgs.Info.Width / System.Convert.ToDouble(concreteBindingContext.OverlapSize.ToColumnCount());

            var contentBoxWidth = columnWidth * (concreteBindingContext.OverlapSize.ToColumnCount() - 1);

            SkiaSharp.SKPath path;

            switch (concreteBindingContext.OverlapShapeKind)
            {
                case Enumerations.OverlapShapeKind.TriangleFullTop:
                    var bottomOvarlapVintageWidth = contentBoxWidth + (columnWidth / 2);

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} L {1} {2} H 0 z", bottomOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), eventArgs.Info.Height));

                    break;

                case Enumerations.OverlapShapeKind.TriangleFullBottom:
                    var topOvarlapVintageWidth = contentBoxWidth + (columnWidth / 2);

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} L {1} {2} H 0 z", contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), topOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), eventArgs.Info.Height));

                    break;

                case Enumerations.OverlapShapeKind.Rectangle:
                default:
                    var paddingSimulationWidth = contentBoxWidth + Wrapper.Width / Providers.ConstantProvider.CONTEXTUAL_OVERLAP_PADDING_BY_WRAPPER_WIDTH_RAZON;

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} V {1} H 0 z", paddingSimulationWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), eventArgs.Info.Height));

                    break;
            }

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.LandscapeContextualTranslucentOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor().WithAlpha(Providers.ConstantProvider.TRANSLUCED_OPACITY_LEVEL)
            };

            eventArgs.Surface.Canvas.DrawPath(path, paint);
        }
    }
}