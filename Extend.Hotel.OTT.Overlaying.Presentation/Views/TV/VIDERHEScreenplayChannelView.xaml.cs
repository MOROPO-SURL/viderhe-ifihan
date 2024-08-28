using MOROPO.VIDERHE.Extend.Common.Presentation.Views;
using MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Helpers.Provisioning;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Views.TV
{
    public partial class VIDERHEScreenplayChannelView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        private Common.Templating.Presentation.Presenters.ScreenplayPresenter screenplayPresenter;
        private System.Guid screenplayId;

        public VIDERHEScreenplayChannelView(System.Guid screenplayId)
        {
            InitializeComponent();

            this.screenplayId = screenplayId;

            IsEnabled = false;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > -1 && !IsEnabled)
            {
                IsEnabled = true;

                var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                client.FilterAsync(new Cloud.Api.Common.Models.Filter.FrameFilterModel { ScreenplayId = screenplayId }).ContinueWith(async task =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        // TODO Handle code block comment!
                        //Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        //{
                        //    DisplayAlert("Aviso", "Se ha presentado un error ...", "OK");

                        //    this.NavigationPopModalPageAsync();
                        //});
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
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            screenplayPresenter?.Dispose();

            screenplayPresenter = null;
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }
    }
}