using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class RightLandscapeContextualTrailOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public RightLandscapeContextualTrailOverlapForImagePlacardView(Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel model)
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel;

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d);

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
                Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Left,
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
                    Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Left,
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
            var concreteBindingContext = BindingContext as Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var columnWidth = eventArgs.Info.Width / System.Convert.ToDouble(concreteBindingContext.OverlapSize.ToColumnCount());

            var contentBoxWidth = columnWidth * (concreteBindingContext.OverlapSize.ToColumnCount() - 1);

            SkiaSharp.SKPath path;

            switch (concreteBindingContext.OverlapShapeKind)
            {
                case Enumerations.OverlapShapeKind.TriangleFullTop:
                    var topOverlapVintageExtraWith = columnWidth / 2;

                    var bottomOvarlapVintageWidth = contentBoxWidth + topOverlapVintageExtraWith;

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {3} 0 h -{0} l {1} {2} H {3} z", bottomOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), topOverlapVintageExtraWith.ToString(System.Globalization.CultureInfo.InvariantCulture), eventArgs.Info.Height, eventArgs.Info.Width));

                    break;

                case Enumerations.OverlapShapeKind.TriangleFullBottom:
                    var bottomOverlapVintageExtraWdith = columnWidth / 2;

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M {3} 0 h -{0} l -{1} {2} H {3} z",
                        contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture),
                        bottomOverlapVintageExtraWdith.ToString(System.Globalization.CultureInfo.InvariantCulture),
                        eventArgs.Info.Height,
                        eventArgs.Info.Width));

                    break;

                case Enumerations.OverlapShapeKind.Rectangle:
                default:
                    var paddingSimulationWidth = contentBoxWidth + Wrapper.Width / Providers.ConstantProvider.CONTEXTUAL_OVERLAP_PADDING_BY_WRAPPER_WIDTH_RAZON;

                    path = SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {2} 0 h -{0} V {1} H {2} z", paddingSimulationWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), eventArgs.Info.Height, eventArgs.Info.Width));

                    break;
            }

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.LandscapeContextualTrailOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(path, paint);
        }
    }
}