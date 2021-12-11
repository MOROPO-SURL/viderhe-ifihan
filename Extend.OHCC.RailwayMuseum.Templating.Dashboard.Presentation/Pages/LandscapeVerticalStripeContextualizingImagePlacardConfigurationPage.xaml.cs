using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Pages
{
    public partial class LandscapeVerticalStripeContextualizingImagePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel>
    {
        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public LandscapeVerticalStripeContextualizingImagePlacardConfigurationPage(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : this (null, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, successfulCompleteCallbackAction)
        {
        }

        public LandscapeVerticalStripeContextualizingImagePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(Factories.LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.CornerTileVideoPresentingVideoTemplateDescriptor();

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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(httpClientHelperProvider);

                if (placardViewModel == null)
                {
                    await client.CreateAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.LandscapeVerticalStripeContextualizingImageTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.LandscapeVerticalStripeContextualizingImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            ContextedImage = BindingContextPageModel.ContextedImage.ToContextModel(),
                            ContextedImageZoomingEnabled = BindingContextPageModel.IsContextedImageZoomingEnabled,
                            StripeColorBackgroundMode = BindingContextPageModel.StripeColorBackgroundMode,
                            IsStripeBackgroundTranslucent = BindingContextPageModel.IsStripeBackgroundTranslucent,
                            Header = BindingContextPageModel.Header,
                            HeaderFontSize = BindingContextPageModel.HeaderFontSize,
                            Content = BindingContextPageModel.Content,
                            ContentFontSize = BindingContextPageModel.ContentFontSize
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.LandscapeVerticalStripeContextualizingImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            ContextedImage = BindingContextPageModel.ContextedImage.ToContextModel(),
                            ContextedImageZoomingEnabled = BindingContextPageModel.IsContextedImageZoomingEnabled,
                            StripeColorBackgroundMode = BindingContextPageModel.StripeColorBackgroundMode,
                            IsStripeBackgroundTranslucent = BindingContextPageModel.IsStripeBackgroundTranslucent,
                            Header = BindingContextPageModel.Header,
                            HeaderFontSize = BindingContextPageModel.HeaderFontSize,
                            Content = BindingContextPageModel.Content,
                            ContentFontSize = BindingContextPageModel.ContentFontSize
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

        private void PickContextedImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(exceptionHandleHelper, httpClientHelperProvider, ContextedImagePicked_Callback, BindingContextPageModel.ContextedImage));
        }

        private void ContextedImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.ContextedImage = selection;
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