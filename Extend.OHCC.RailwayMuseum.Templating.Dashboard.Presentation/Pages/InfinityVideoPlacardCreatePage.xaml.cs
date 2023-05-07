using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Pages
{
    public partial class InfinityVideoPlacardCreatePage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.InfinityVideoPlacardCreatePageModel>
    {
        private Descriptors.InfinityVideoTemplateDescriptor templateDescriptor;
        private System.Action successfulCompleteCallbackAction;

        public InfinityVideoPlacardCreatePage(Support.Presentation.Models.View.VideoViewModel videoViewModel, Descriptors.InfinityVideoTemplateDescriptor templateDescriptor, System.Action successfulCompleteCallbackAction)
            : base(new Models.Page.InfinityVideoPlacardCreatePageModel
            {
                Video = videoViewModel,
                Label = videoViewModel.About
            })
        {
            InitializeComponent();

            this.templateDescriptor = templateDescriptor;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Cloud.Api.Common.Models.PlacardInputModel
                {
                    Label = BindingContextPageModel.Label,
                    TemplateId = templateDescriptor.Id,
                    PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.InfinityVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                        Video = BindingContextPageModel.Video.ToContextModel(),
                        StartMargin = BindingContextPageModel.StartMargin,
                        EndMargin = BindingContextPageModel.EndMargin
                    })
                };

                if (BindingContextPageModel.DefineBeginAt)
                {
                    model.BeginAt = BindingContextPageModel.BeginAt;
                }

                if (BindingContextPageModel.DefineEndAt)
                {
                    model.EndAt = BindingContextPageModel.EndAt;
                }

                await client.CreateAsync(model);
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

            templateDescriptor = null;
            successfulCompleteCallbackAction = null;
        }
    }
}