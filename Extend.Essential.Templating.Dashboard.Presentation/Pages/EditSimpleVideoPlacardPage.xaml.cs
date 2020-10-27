using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class EditSimpleVideoPlacardPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EditSimpleVideoPlacardPageModel>
    {
        private Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel contextModel;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public EditSimpleVideoPlacardPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(Factories.EditSimpleVideoPlacardPageModelFactory.Build(placardViewModel, cloudServerProvider))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel>(placardViewModel.SerializedContext);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiClient(httpClientHelperProvider);

                await client.EditAsync(new Cloud.Api.Common.Models.PlacardInputModel
                {
                    Id = placardViewModel.Id,
                    Label = BindingContextPageModel.Label,
                    TemplateId = placardViewModel.Template.Id,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                        VideoId = contextModel.VideoId,
                        VideoExtension = contextModel.VideoExtension,
                        ThumbnailId = contextModel.ThumbnailId
                    })
                });
            }).ContinueWith((System.Threading.Tasks.Task task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null)
                    {
                        exceptionHandleHelper.HandleException(task.Exception);
                    }
                    else
                    {
                        notificationPresenter.PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        successfulCompleteCallbackAction.Invoke();
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            contextModel = null;

            placardViewModel = null;
            httpClientHelperProvider = null;
            notificationPresenter = null;
            successfulCompleteCallbackAction = null;
        }
    }
}