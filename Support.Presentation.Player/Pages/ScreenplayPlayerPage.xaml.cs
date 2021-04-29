using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Player.Pages
{
    public partial class ScreenplayPlayerPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private Viderhe.Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider;
        private Providers.Facade.ICloudServerProviderFacade cloudServerProvider;

        private Viderhe.Extend.Common.Templating.Presentation.Presenters.ScreenplayPresenter presenter;

        private readonly bool demo;

        public ScreenplayPlayerPage(Models.View.PlacardViewModel[] placards, System.Action presentationCompleteCallbackAction, bool loop, Viderhe.Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Providers.Facade.ICloudServerProviderFacade cloudServerProvider, System.Action<System.Guid> placardPlayingCallbackAction = null, Viderhe.Extend.Common.Overlaying.Presentation.Views.BaseOverlayView overlay = null, System.Action<BasePlacardPresentationView, BasePlacardPresentationView> placardViewTransitionCompleteCallbackAction = null)
        {
            InitializeComponent();

            this.accountInformationProvider = accountInformationProvider;
            this.cloudServerProvider = cloudServerProvider;

            presenter = new Viderhe.Extend.Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards, accountInformationProvider, Extend.Motion.Presentation.Providers.MotionTransitionProvider.Instance, presentationCompleteCallbackAction, loop, placardPlayingCallbackAction, placardViewTransitionCompleteCallbackAction);

            if (overlay != null)
            {
                OverlayContainer.Content = overlay;
            }

            demo = !loop;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Xamarin.Essentials.DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;

            if (!demo)
            {
                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith((System.Threading.Tasks.Task task) =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(presenter.BeginPresentation);
                });

                return;
            }

            presenter.BeginPresentation();
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, Xamarin.Essentials.DisplayInfoChangedEventArgs e)
        {
            if (presenter.CurrentPlacardViewModel == null) return;

            if (!presenter.CurrentPlacardViewModel.SupportedByMainDisplayOrientation())
            {
                presenter.RequestPresentNextFrame();
            }
        }

        public void RequestPresentNextFrame()
        {
            presenter.RequestPresentNextFrame();
        }

        public void RequestPresentPreviousFrame()
        {
            presenter.RequestPresentPreviousFrame();
        }

        public void RequestRestar(Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode immediacyMode)
        {
            presenter.RequestRestar(immediacyMode);
        }

        public void RequestReload(Cloud.SignalR.Connect.Common.Enumerations.ScreenplayHandlingImmediacyMode immediacyMode)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                presenter.RequestReload(immediacyMode);
            });
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(Models.View.PlacardViewModel model)
        {
            return Extend.Templating.Presentation.Providers.PlacardPresentationViewProvider.Instance.GetFor(model, accountInformationProvider, cloudServerProvider);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Xamarin.Essentials.DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;

            accountInformationProvider = null;
            cloudServerProvider = null;

            presenter.Dispose();

            presenter = null;
        }
    }
}