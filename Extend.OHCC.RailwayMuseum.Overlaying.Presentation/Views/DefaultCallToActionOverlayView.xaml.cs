namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Views
{
    public partial class DefaultCallToActionOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        private static readonly System.TimeSpan CALL_TO_ACTION_DELAY = System.TimeSpan.FromSeconds(5);

        private readonly System.Action<object> overlayTapCallbackAction;
        private SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.HeartAnimation callToActionAnimation;


        public DefaultCallToActionOverlayView(System.Action<object> overlayTapCallbackAction, object model = null)
        {
            InitializeComponent();

            this.overlayTapCallbackAction = overlayTapCallbackAction;

            BindingContext = model;

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            var expectedWidth = Xamarin.Forms.Application.Current.MainPage.Width / 5;

            CallToActionMessageWrapGrid.WidthRequest = expectedWidth;
            CallToActionMessageWrapGrid.HeightRequest = expectedWidth;

            CallToActionMessageBackgroundBoxView.Color = accountInformationProvider.PrimaryColor;
            CallToActionMessageBackgroundBoxView.CornerRadius = new Xamarin.Forms.CornerRadius(expectedWidth, 0, 0, 0);

            var labelPaddingComponent = expectedWidth * 2d / 3d * 0.2;

            CallToActionMessageWrapStackLayout.Padding = new Xamarin.Forms.Thickness(0, 0, labelPaddingComponent, labelPaddingComponent);

            System.Threading.Tasks.Task.Delay(CALL_TO_ACTION_DELAY).ContinueWith(_ => Xamarin.Forms.Device.BeginInvokeOnMainThread(StartCallToActionAnimation));
        }

        public override void ShowIn()
        {
        }

        public override void ShowOut()
        {
        }

        private void OverlayTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            overlayTapCallbackAction?.Invoke(BindingContext);
        }

        private void CallToActionAnimation_Completed(object sender, System.EventArgs eventArgs)
        {
            CallToActionMessageWrapGrid.Scale = 1;

            System.Threading.Tasks.Task.Delay(CALL_TO_ACTION_DELAY).ContinueWith(_ =>
            {
                callToActionAnimation?.Begin();
            });
        }

        private void StartCallToActionAnimation()
        {
            if (callToActionAnimation != null) return;

            callToActionAnimation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.HeartAnimation
            {
                Target = CallToActionMessageWrapGrid
            };

            callToActionAnimation.Completed += CallToActionAnimation_Completed;

            callToActionAnimation.Begin();
        }
    }
}