using SkiaSharp.Views.Forms;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class RightLandscapeContextualTrailOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public RightLandscapeContextualTrailOverlapForImagePlacardView(TrailContextualOverlapForImagePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            var overlapSizeToColumnSpanConverter = (Converters.OverlapSizeToColumnSpanConverter)Resources["OverlapSizeToColumnSpanConverter"];
            var overlapSizeToRightColumnIndexConverter = (Converters.OverlapSizeToRightColumnIndexConverter)Resources["OverlapSizeToRightColumnIndexConverter"];

            OverlapLayout.IsVisible = false;

            var singleTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Single };

            Xamarin.Forms.Grid.SetColumn(singleTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(singleTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            singleTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(0, singleTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Single) return;

            var dualTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Dual };

            Xamarin.Forms.Grid.SetColumn(dualTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(dualTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            dualTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(1, dualTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Dual) return;

            var triplexTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Triplex };

            Xamarin.Forms.Grid.SetColumn(triplexTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(triplexTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            triplexTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(2, triplexTrailConvasView);

            if (model.OverlapTrailMode == Enumerations.OverlapTrailMode.Triplex) return;

            var fourfoldTrailConvasView = new SKCanvasView { BindingContext = Enumerations.OverlapTrailMode.Fourfold };

            Xamarin.Forms.Grid.SetColumn(fourfoldTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(fourfoldTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(Enumerations.OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

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

            var contentBoxWidth = Width * ((concreteBindingContext.OverlapSize.ToColumnCount() - 1) / 6d);

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

            if (concreteBindingContext.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = ContextedImagen,
                    TranslateX = concreteBindingContext.OverlapAlignment == Enumerations.OverlapAlignment.Start ? contentBoxWidth / 2 : contentBoxWidth / 2 * -1,
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicInOut,
                    Delay = "100"
                });
            }

            var index = 0;

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
            var concreteBindingContext = BindingContext as TrailContextualOverlapForImagePlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as TrailContextualOverlapForImagePlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width), paint);
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

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width, Wrapper.Width * 0.02 * ((int)canvasView.BindingContext + 1)), paint);
        }
    }
}