using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;
using SkiaSharp.Views.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views
{
    public partial class PortraitTranslucentContextualOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitTranslucentContextualOverlapForImagePlacardView(Models.View.PortraitTranslucentContextualOverlapForImagePlacardViewModel model)
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

            var concreteBindingContext = BindingContext as Models.View.PortraitTranslucentContextualOverlapForImagePlacardViewModel;

            OverlapLayout.TranslationY = concreteBindingContext.OverlapVerticalAlignment == Enumerations.OverlapVerticalAlignment.Top ? Height * -1 : Height;

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
            {
                Target = OverlapLayout,
                TranslateY = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });
            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = TitleLabel,
                Direction = concreteBindingContext.OverlapVerticalAlignment == Enumerations.OverlapVerticalAlignment.Top ? XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down : XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
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
                    Direction = concreteBindingContext.OverlapVerticalAlignment == Enumerations.OverlapVerticalAlignment.Top ? XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down : XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();

            if (concreteBindingContext.ContextedImageZoomingEnabled && concreteBindingContext.ScreenPresentationTime > System.TimeSpan.Zero)
            {
                var presentedImageZoominAnimation = new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = ContextedImagen,
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
        }

        private void OverlapContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as Models.View.PortraitTranslucentContextualOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as Models.View.PortraitTranslucentContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor().WithAlpha(Providers.ConstantProvider.TRANSLUCED_OPACITY_LEVEL)
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.OverlapShapeKind.ToVerticalSKPath(concreteBindingContext.OverlapVerticalAlignment, eventArgs.Info.Width, eventArgs.Info.Height, OverlapContentLayout.Height), paint);
        }
    }
}