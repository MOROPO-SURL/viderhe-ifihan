using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Helpers.Provisioning;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using System.Linq;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Pages
{
    public partial class BrandChannelPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action presentationCompleteCallbackAction;

        private Common.Templating.Presentation.Presenters.ScreenplayPresenter screenplayPresenter;

        private Models.Context.OTTHotelTVOverlayContextModel context;

        public BrandChannelPage(Models.Context.OTTHotelTVOverlayContextModel context, System.Action presentationCompleteCallbackAction)
        {
            InitializeComponent();

            this.context = context;
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            client.FilterAsync(new Cloud.Api.Common.Models.Filter.FrameFilterModel { ScreenplayId = context.BrandChannelScreenplayId }).ContinueWith(async task =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Aviso", "Se ha presentado un error ...", "OK");

                        this.NavigationPopModalPageAsync();
                    });
                }

                var frames = task.Result.OrderBy(e => e.Priority).ToArray();

                var placardList = new System.Collections.Generic.List<PlacardViewModel>();

                foreach (var model in frames)
                {
                    var item = model.Placard.ToViewModel();

                    var completitionHelper = Support.Extend.Templating.Presentation.Providers.PlacardViewModelCompletitionHelperProvider.Instance.GetFor(model.Placard);

                    if (completitionHelper != null)
                    {
                        await completitionHelper.CompleteAsync(item);
                    }

                    placardList.Add(item);
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => 
                {
                    screenplayPresenter = new Common.Templating.Presentation.Presenters.ScreenplayPresenter(ScreenplayWrapperGrid, PlacardViewModelToPresentationView, placardList.ToArray(), Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, null, true, null);

                    screenplayPresenter.BeginPresentation();
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            presentationCompleteCallbackAction = null;

            screenplayPresenter?.Dispose();

            screenplayPresenter = null;
            context = null;
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            this.NavigationPopModalPageAsync();

            presentationCompleteCallbackAction?.Invoke();
        }
    }
}