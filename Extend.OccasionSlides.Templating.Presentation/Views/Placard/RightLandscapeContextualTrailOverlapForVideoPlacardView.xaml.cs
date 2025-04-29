using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;
using SkiaSharp.Views.Forms;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class RightLandscapeContextualTrailOverlapForVideoPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition;

        public RightLandscapeContextualTrailOverlapForVideoPlacardView(TrailContextualOverlapForVideoPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            var overlapSizeToColumnSpanConverter = (OverlapSizeToColumnSpanConverter)Resources["OverlapSizeToColumnSpanConverter"];
            var overlapSizeToRightColumnIndexConverter = (OverlapSizeToRightColumnIndexConverter)Resources["OverlapSizeToRightColumnIndexConverter"];

            OverlapLayout.IsVisible = false;

            var singleTrailConvasView = new SKCanvasView { BindingContext = OverlapTrailMode.Single };

            Xamarin.Forms.Grid.SetColumn(singleTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(singleTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            singleTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(0, singleTrailConvasView);

            if (model.OverlapTrailMode == OverlapTrailMode.Single) return;

            var dualTrailConvasView = new SKCanvasView { BindingContext = OverlapTrailMode.Dual };

            Xamarin.Forms.Grid.SetColumn(dualTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(dualTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            dualTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(1, dualTrailConvasView);

            if (model.OverlapTrailMode == OverlapTrailMode.Dual) return;

            var triplexTrailConvasView = new SKCanvasView { BindingContext = OverlapTrailMode.Triplex };

            Xamarin.Forms.Grid.SetColumn(triplexTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(triplexTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

            triplexTrailConvasView.PaintSurface += OverlapContentWrapTrailCanvasView_PaintSurface;

            OverlapLayout.Children.Insert(2, triplexTrailConvasView);

            if (model.OverlapTrailMode == OverlapTrailMode.Triplex) return;

            var fourfoldTrailConvasView = new SKCanvasView { BindingContext = OverlapTrailMode.Fourfold };

            Xamarin.Forms.Grid.SetColumn(fourfoldTrailConvasView, (int)overlapSizeToRightColumnIndexConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));
            Xamarin.Forms.Grid.SetColumnSpan(fourfoldTrailConvasView, (int)overlapSizeToColumnSpanConverter.Convert(model.OverlapSize, typeof(OverlapSize), null, System.Globalization.CultureInfo.CurrentCulture));

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

        //private void VideoPlayer_StatusUpdated(object sender, System.EventArgs eventArgs)
        //{
        //    var videoPlayer = sender as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView;

        //    if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
        //    {
        //        videoPlayer.StatusUpdated -= VideoPlayer_StatusUpdated;

        //        EndPresentation();
        //    }
        //    else if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
        //    {
        //        transition?.PerformMotion();

        //        transition = null;
        //    }
        //}

        public override void StartShowInWhenReady(Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition)
        {
            //if (ContextedVideo.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            if (ContextedVideo.CurrentState == Xamarin.CommunityToolkit.UI.Views.MediaElementState.Playing)
            {
                base.StartShowInWhenReady(transition);

                return;
            }

            this.transition = transition;
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContext = BindingContext as TrailContextualOverlapForVideoPlacardViewModel;

            var contentBoxWidth = Width * ((concreteBindingContext.OverlapSize.ToColumnCount() - 1) / 6d);

            foreach (var item in InfoBlocksLayout.Children)
            {
                if (item.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                item.Opacity = 0;
            }

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d);

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = OverlapLayout,
                TranslateX = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });

            if (concreteBindingContext.ContextedVideoCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = ContextedVideo,
                    TranslateX = concreteBindingContext.OverlapAlignment == OverlapAlignment.Start ? contentBoxWidth / 2 : contentBoxWidth / 2 * -1,
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
                    Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Left,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedVideo.Source = null;

            this.transition = null;
        }

        private void VideoPlayerView_MediaOpened(object sender, System.EventArgs e)
        {
            transition?.PerformMotion();

            transition = null;
        }

        private void VideoPlayerView_MediaEnded(object sender, System.EventArgs e)
        {
            EndPresentation();
        }

        private void OverlapContentWrapLayout_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as TrailContextualOverlapForVideoPlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as TrailContextualOverlapForVideoPlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width), paint);
        }

        private void OverlapContentWrapTrailCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as TrailContextualOverlapForVideoPlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var canvasView = sender as SKCanvasView;

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as TrailContextualOverlapForVideoPlacardViewModel).OverlapBackgroundColor.MultiplyAlpha(1 - ((int)canvasView.BindingContext + 1) / ((int)concreteBindingContext.OverlapTrailMode + 2d)).ToSKColor()
            };

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width, Wrapper.Width * 0.02 * ((int)canvasView.BindingContext + 1)), paint);
        }
    }
}