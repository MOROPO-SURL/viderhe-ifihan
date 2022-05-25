using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Pages
{
    public partial class InfinityVideoPlacardEditPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.InfinityVideoPlacardEditPageModel>
    {
        private Templating.Models.Context.InfinityVideoPlacardContextModel contextModel;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public InfinityVideoPlacardEditPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.InfinityVideoPlacardEditPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.InfinityVideoPlacardContextModel>(placardViewModel.SerializedContext);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                await client.EditAsync(new Cloud.Api.Common.Models.PlacardInputModel
                {
                    Id = placardViewModel.Id,
                    PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                    Label = BindingContextPageModel.Label,
                    TemplateId = placardViewModel.Template.Id,
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.InfinityVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                        Video = contextModel.Video,
                        StartMargin = BindingContextPageModel.StartMargin,
                        EndMargin = BindingContextPageModel.EndMargin
                    })
                });
            }).ContinueWith((System.Threading.Tasks.Task task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

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

            contextModel = null;

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
        }
    }
}