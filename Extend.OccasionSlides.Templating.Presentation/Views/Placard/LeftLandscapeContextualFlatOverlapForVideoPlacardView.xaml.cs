using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;
using SkiaSharp.Views.Forms;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class LeftLandscapeContextualFlatOverlapForVideoPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition;

        public LeftLandscapeContextualFlatOverlapForVideoPlacardView(FlatContextualOverlapForVideoPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

        private void VideoPlayer_StatusUpdated(object sender, System.EventArgs eventArgs)
        {
            var videoPlayer = sender as SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoPlayerView;

            if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Ended)
            {
                videoPlayer.StatusUpdated -= VideoPlayer_StatusUpdated;

                EndPresentation();
            }
            else if (videoPlayer.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            {
                transition?.PerformMotion();

                transition = null;
            }
        }

        public override void StartShowInWhenReady(Common.Transitioning.Presentation.Transitions.Contract.AbstractTransition transition)
        {
            if (ContextedVideo.Status == SmartSolucionesCuba.XFToolKit.Presentation.Views.Rendered.VideoStatus.Playing)
            //if (ContextedVideo.CurrentState == Xamarin.CommunityToolkit.UI.Views.MediaElementState.Playing)
            {
                base.StartShowInWhenReady(transition);

                return;
            }

            this.transition = transition;
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContext = BindingContext as FlatContextualOverlapForVideoPlacardViewModel;

            foreach (var item in InfoBlocksLayout.Children)
            {
                if (item.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                item.Opacity = 0;
            }

            var contentBoxWidth = Width * ((concreteBindingContext.OverlapSize.ToColumnCount() - 1) / 6d);

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d) * -1;

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
                    Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
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

            transition = null;
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
            var concreteBindingContext = BindingContext as FlatContextualOverlapForVideoPlacardViewModel;

            eventArgs.Surface.Canvas.Clear();

            var paint = new SkiaSharp.SKPaint()
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = (BindingContext as FlatContextualOverlapForVideoPlacardViewModel).OverlapBackgroundColor.ToSKColor()
            };

            if (concreteBindingContext.UseOverlapShadown)
            {
                var shadowRawColors = new string[] { "#090806", "#15120e", "#211d16", "#2c271e", "#383126", "#443b2e", "#4f4636", "#5b503d", "#675a45", "#655a45", "#73644d" };

                var index = (int)((BindingContext as FlatContextualOverlapForVideoPlacardViewModel).OverlapBackgroundColor.Luminosity * 10);

                paint.ImageFilter = SkiaSharp.SKImageFilter.CreateDropShadow(7f, 0f, 8f, 8f, SkiaSharp.SKColor.Parse(shadowRawColors[index]));
            }

            eventArgs.Surface.Canvas.DrawPath(concreteBindingContext.ToHorizontalSKPath(eventArgs.Info.Width, eventArgs.Info.Height, Wrapper.Width), paint);
        }
    }
}