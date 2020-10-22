namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class SimpleVideoPlacardView : Common.Presentation.Views.BasePlacardPresentationView
    {
        public SimpleVideoPlacardView(Models.View.SimpleVideoPlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => VideoPlayerView;

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
    }
}