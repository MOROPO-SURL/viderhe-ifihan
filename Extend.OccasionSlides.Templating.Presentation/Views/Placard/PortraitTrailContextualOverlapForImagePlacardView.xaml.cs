using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class PortraitTrailContextualOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitTrailContextualOverlapForImagePlacardView(TrailContextualOverlapForImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            OverlapLayout.IsVisible = false;

            var singleTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Single };

            singleTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(0, singleTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Single) return;

            var dualTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Dual };

            dualTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(1, dualTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Dual) return;

            var triplexTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Triplex };

            triplexTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(2, triplexTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Triplex) return;

            var fourfoldTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Fourfold };

            fourfoldTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(3, fourfoldTrailConvasView);
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

            var concreteBindingContext = BindingContext as TrailContextualOverlapForImagePlacardViewModel;

            foreach (var item in InfoBlocksLayout.Children)
            {
                if (item.BindingContext is Models.View.Block.TransparentSeparatorContentBlockViewModel) continue;

                item.Opacity = 0;
            }

            OverlapLayout.TranslationY = concreteBindingContext.OverlapAlignment == Enumerations.OverlapAlignment.Start ? Height * -1 : Height;

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
            if (concreteBindingContext.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                {
                    Target = ContextedImageWrapper,
                    TranslateY = concreteBindingContext.OverlapAlignment == Enumerations.OverlapAlignment.Start ? OverlapContentLayout.Height / 2 : OverlapContentLayout.Height / 2 * -1,
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicInOut,
                    Delay = "100"
                });
            }

            var index = 0;

            foreach (var infoBlockLayout in InfoBlocksLayout.Children)
            {
                if (infoBlockLayout.BindingContext is Models.View.Block.TransparentSeparatorContentBlockViewModel) continue;

                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Target = infoBlockLayout,
                    Direction = concreteBindingContext.OverlapAlignment == Enumerations.OverlapAlignment.Start ? XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down : XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
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
            var concreteBindingContext = BindingContext as TrailContextualOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as TrailContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.OverlapShapeKind.ToVerticalSKPath(concreteBindingContext.OverlapAlignment, eventArgs.Info.Width, eventArgs.Info.Height, OverlapContentLayout.Height), paint);
        }

        private void OverlapContentWrapTrailCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as TrailContextualOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var canvasView = sender as SKCanvasView;

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as TrailContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.MultiplyAlpha(1 - ((int)canvasView.BindingContext + 1) / ((int)concreteBindingContext.OverlapTrailMode + 2d)).ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.OverlapShapeKind.ToVerticalSKPath(concreteBindingContext.OverlapAlignment, eventArgs.Info.Width, eventArgs.Info.Height, OverlapContentLayout.Height, Wrapper.Height * 0.02 * ((int)canvasView.BindingContext + 1)), paint);
        }
    }
}