using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Dashboard.Presentation.Pages
{
    public partial class PortraitPosterVideoEventPromotionEventPlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageModel>
    {
        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public PortraitPosterVideoEventPromotionEventPlacardConfigurationPage(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : this(null, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, successfulCompleteCallbackAction)
        {
        }

        public PortraitPosterVideoEventPromotionEventPlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(Factories.PortraitPosterVideoEventPromotionEventPlacardConfigurationPageFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor();

                Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Marco ({0})", placardViewModel.Template.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiClient(httpClientHelperProvider);

                if (placardViewModel == null)
                {
                    await client.CreateAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            Poster = BindingContextPageModel.EventPoster.ToContextModel(),
                            Video = BindingContextPageModel.EventVideo.ToContextModel()
                        })
                    });
                }
                else
                {
                    await client.EditAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Id = placardViewModel.Id,
                        Label = BindingContextPageModel.Label,
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.PortraitPosterVideoEventPromotionPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            Poster = BindingContextPageModel.EventPoster.ToContextModel(),
                            Video = BindingContextPageModel.EventVideo.ToContextModel()
                        })
                    });
                }
            }).ContinueWith(task =>
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

        private void PickEventPosterButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(exceptionHandleHelper, httpClientHelperProvider, EventPosterPickedCallback, BindingContextPageModel.EventPoster));
        }

        private void PickEventVideoButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoPickPage(exceptionHandleHelper, EventVideoPickedCallback, httpClientHelperProvider, BindingContextPageModel.EventVideo));
        }

        private void EventVideoPickedCallback(Support.Presentation.Models.View.VideoViewModel selection)
        {
            BindingContextPageModel.EventVideo = selection;
        }

        private void EventPosterPickedCallback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.EventPoster = selection;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            httpClientHelperProvider = null;
            exceptionHandleHelper = null;
            notificationPresenter = null;
            successfulCompleteCallbackAction = null;
        }
    }
}