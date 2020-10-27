using SmartSolucionesCuba.Videre.Extend.Common.Presentation.Views;

namespace SmartSolucionesCuba.Videre.Support.Presentation.Player.Pages
{
    public partial class ScreenplayPlayerPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private Providers.Facade.ICloudServerProviderFacade cloudServerProvider;
        private Videre.Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider;

        private Videre.Extend.Common.Templating.Presentation.Presenters.ScreenplayPresenter presenter;

        private readonly bool demo;

        public ScreenplayPlayerPage(Models.View.PlacardViewModel[] placards, System.Action presentationCompleteCallbackAction, bool loop, System.Action<System.Guid> placardPlayingCallbackAction = null, Videre.Extend.Common.Overlaying.Presentation.Views.BaseOverlayView overlay = null, System.Action<BasePlacardPresentationView, BasePlacardPresentationView> placardViewTransitionCompleteCallbackAction = null)
        {
            InitializeComponent();

            cloudServerProvider = XFToolKit.IoC.TinyIoCContainer.Current.Resolve<Providers.Facade.ICloudServerProviderFacade>();
            accountInformationProvider = XFToolKit.IoC.TinyIoCContainer.Current.Resolve<Videre.Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            presenter = new Videre.Extend.Common.Templating.Presentation.Presenters.ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards, accountInformationProvider, Extend.Motion.Presentation.Providers.MotionTransitionProvider.Instance, presentationCompleteCallbackAction, loop, placardPlayingCallbackAction, placardViewTransitionCompleteCallbackAction);

            if (overlay != null)
            {
                OverlayContainer.Content = overlay;
            }

            demo = !loop;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

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
            return Extend.Templating.Presentation.Providers.PlacardPresentationViewProvider.Instance.GetFor(model);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            cloudServerProvider = null;
            accountInformationProvider = null;

            presenter.Dispose();

            presenter = null;
        }
    }
}