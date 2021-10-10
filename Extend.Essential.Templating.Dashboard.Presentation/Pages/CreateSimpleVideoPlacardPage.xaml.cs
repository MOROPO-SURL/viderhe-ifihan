using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class CreateSimpleVideoPlacardPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.CreateSimpleVideoPlacardPageModel>
    {
        private Descriptors.SimpleVideoTemplateDescriptor templateDescriptor;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public CreateSimpleVideoPlacardPage(Support.Presentation.Models.View.VideoViewModel videoViewModel, Descriptors.SimpleVideoTemplateDescriptor templateDescriptor, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(new Models.Page.CreateSimpleVideoPlacardPageModel
            {
                Video = videoViewModel,
                Label = videoViewModel.About
            })
        {
            InitializeComponent();

            this.templateDescriptor = templateDescriptor;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(httpClientHelperProvider);

                await client.CreateAsync(new Cloud.Api.Common.Models.PlacardInputModel
                {
                    Label = BindingContextPageModel.Label,
                    TemplateId = templateDescriptor.Id,
                    PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                        Video = BindingContextPageModel.Video.ToContextModel()
                    })
                });
            }).ContinueWith((System.Threading.Tasks.Task task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
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

        private void VideoPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.Video));
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            templateDescriptor = null;
            httpClientHelperProvider = null;
            exceptionHandleHelper = null;
            notificationPresenter = null;
            successfulCompleteCallbackAction = null;
        }
    }
}