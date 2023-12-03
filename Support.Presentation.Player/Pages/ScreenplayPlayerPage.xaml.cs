using MOROPO.VIDERHE.Cloud.SignalR.Connect.Common.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters.Facade;
using MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Helpers.Provisioning;
using MOROPO.VIDERHE.Support.Extend.Transitioning.Presentation.Providers;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Support.Presentation.Player.Pages
{
    public partial class ScreenplayPlayerPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private ScreenplayPresenter presenter;

        private readonly bool demo;
        private readonly bool empty;

        public ScreenplayPlayerPage(PlacardViewModel[] placards, System.Action presentationEndedCallbackAction, bool loop, System.Action<System.Guid> placardPlayingCallbackAction = null, System.Action screenplayPresentIterationCompleteCallbackAction = null, VIDERHE.Extend.Common.Overlaying.Presentation.Views.BaseOverlayView overlay = null, System.Action<BasePlacardPresentationView, BasePlacardPresentationView> placardViewTransitionCompleteCallbackAction = null)
        {
            InitializeComponent();

            presenter = new ScreenplayPresenter(FramesContainer, PlacardViewModelToPresentationView, placards, TransitionProvider.Instance, presentationEndedCallbackAction, loop, placardPlayingCallbackAction, screenplayPresentIterationCompleteCallbackAction, placardViewTransitionCompleteCallbackAction);

            Xamarin.Forms.DependencyService.RegisterSingleton<IOvarlablePresenter>(presenter);

            if (overlay != null)
            {
                OverlayContainer.Content = overlay;
            }

            demo = !loop;
            empty = placards.Length <= 0;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            IsEnabled = true;

            Xamarin.Essentials.DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;

            if (!demo)
            {
                if (empty) return;

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(5)).ContinueWith(task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(presenter.BeginPresentation);
                });

                return;
            }

            presenter.BeginPresentation();
        }

        protected override bool OnBackButtonPressed()
        {
            this.NavigationPopModalPageAsync();

            return true;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, Xamarin.Essentials.DisplayInfoChangedEventArgs e)
        {
            RequestPresentNextFrame();
        }

        public void RequestPresentNextFrame()
        {
            presenter.RequestPresentNextFrame();
        }

        public void RequestPresentPreviousFrame()
        {
            presenter.RequestPresentPreviousFrame();
        }

        public void PresentInterventionPlacards(PlacardViewModel[] placards)
        {
            presenter.PresentInterventionPlacards(placards);
        }

        public void RequestRestart(ScreenplayHandlingImmediacyMode immediacyMode)
        {
            presenter.RequestRestart(immediacyMode);
        }

        public void RequestReload(ScreenplayHandlingImmediacyMode immediacyMode)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                presenter.RequestReload(immediacyMode);
            });
        }

        public void RequestPausePresentation()
        {

        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Xamarin.Essentials.DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;

            presenter.Dispose();

            presenter = null;

            // TODO Check for alternative!!
            //MediaManager.CrossMediaManager.Current.Stop();

            Xamarin.Forms.DependencyService.RegisterSingleton<IOvarlablePresenter>(null);
        }
    }
}