using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;
using SkiaSharp.Views.Forms;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class PortraitFlatContextualOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitFlatContextualOverlapForImagePlacardView(FlatContextualOverlapForImagePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            var concreteBindingContext = BindingContext as FlatContextualOverlapForImagePlacardViewModel;

            foreach (var item in InfoBlocksLayout.Children)
            {
                if (item.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                item.Opacity = 0;
            }

            OverlapLayout.TranslationY = concreteBindingContext.OverlapAlignment == OverlapAlignment.Start ? Height * -1 : Height;

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
            {
                Target = OverlapLayout,
                TranslateY = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });
            if (concreteBindingContext.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                {
                    Target = ContextedImageWrapper,
                    TranslateY = concreteBindingContext.OverlapAlignment == OverlapAlignment.Start ? OverlapContentLayout.Height / 2 : OverlapContentLayout.Height / 2 * -1,
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicInOut,
                    Delay = "100"
                });
            }

            var index = 0;

            foreach (var infoBlockLayout in InfoBlocksLayout.Children)
            {
                if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Target = infoBlockLayout,
                    Direction = concreteBindingContext.OverlapAlignment == OverlapAlignment.Start ? SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down : SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();

            if (concreteBindingContext.ContextedImageZoomingEnabled && concreteBindingContext.ScreenPresentationTime > System.TimeSpan.Zero)
            {
                var presentedImageZoominAnimation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = ContextedImageWrapper,
                    Scale = 1.2,
                    Duration = concreteBindingContext.ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                presentedImageZoominAnimation.Begin();
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImagen.Source = null;
            ContextedImageThumbnailImage.Source = null;
        }

        private void OverlapContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as FlatContextualOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as FlatContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            if (concreteBindingContext.UseOverlapShadown)
            {
                var shadowRawColors = new string[] { "#090806", "#15120e", "#211d16", "#2c271e", "#383126", "#443b2e", "#4f4636", "#5b503d", "#675a45", "#655a45", "#73644d" };

                var index = (int)((BindingContext as FlatContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.Luminosity * 10);

                paint.ImageFilter = SkiaSharp.SKImageFilter.CreateDropShadow(7f, 0f, 8f, 8f, SkiaSharp.SKColor.Parse(shadowRawColors[index]));
            }

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.OverlapShapeKind.ToVerticalSKPath(concreteBindingContext.OverlapAlignment, eventArgs.Info.Width, eventArgs.Info.Height, OverlapContentLayout.Height), paint);
        }
    }
}