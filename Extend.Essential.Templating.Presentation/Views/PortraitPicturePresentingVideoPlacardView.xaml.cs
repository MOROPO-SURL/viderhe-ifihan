namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class PortraitPicturePresentingVideoPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitPicturePresentingVideoPlacardView(Models.View.PortraitPicturePresentingVideoPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
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
            var videoPlayer = sender as XFToolKit.Presentation.Views.Rendered.VideoPlayerView;

            if (videoPlayer.Status == XFToolKit.Presentation.Views.Rendered.VideoStatus.Paused)
            {
                videoPlayer.StatusUpdated -= VideoPlayer_StatusUpdated;

                EndPresentation();
            }
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var model = BindingContext as Models.View.PortraitPicturePresentingVideoPlacardViewModel;

            var height = PlacardLayout.Width * model.PresenterImageHeigth / model.PresenterImageWidth;

            if (model.PresenterSide == Enumerations.PortraitPresentationSide.Top)
            {
                PresenterImage.TranslationY = height * -1;
            }
            else
            {
                PresenterImage.TranslationY = height;
            }

            PresenterImage.IsVisible = true;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
            {
                Target = PresenterImage,
                TranslateY = 0,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
            });

            if (model.PresentedVideoCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                {
                    Target = PresentedVideo,
                    TranslateY = model.PresenterSide == Enumerations.PortraitPresentationSide.Top ? height / 2 : height / 2 * -1,
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Delay = "100"
                });
            }

            internalShowInStoryboard.Begin();
        }
    }
}