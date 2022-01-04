using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages
{
    public partial class LandscapeTranslucentOverlayContextedImagePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel>
    {
        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public LandscapeTranslucentOverlayContextedImagePlacardConfigurationPage(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : this(null, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, successfulCompleteCallbackAction)
        {
        }

        public LandscapeTranslucentOverlayContextedImagePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(Factories.LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.LandscapeTranslucentOverlayContextedImageTemplateDescriptor();

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
                        TemplateId = Descriptors.LandscapeTranslucentOverlayContextedImageTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.LandscapeTranslucentOverlayContextedImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            ContextedImage = BindingContextPageModel.ContextedImage.ToContextModel(),
                            OverlaySize = BindingContextPageModel.OverlaySize,
                            OverlayShapeKind = BindingContextPageModel.OverlayShapeKind,
                            OverlayHorizontalAlignment = BindingContextPageModel.OverlayHorizontalAlignment,
                            OverlayBackgroundColor = BindingContextPageModel.OverlayBackgroundColor.ToHex(),
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            Title = BindingContextPageModel.Title,
                            TitleFontSize = BindingContextPageModel.TitleFontSize,
                            InfoBlocks = BindingContextPageModel.InfoBlocks.ToArray()
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.LandscapeTranslucentOverlayContextedImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            ContextedImage = BindingContextPageModel.ContextedImage.ToContextModel(),
                            OverlaySize = BindingContextPageModel.OverlaySize,
                            OverlayShapeKind = BindingContextPageModel.OverlayShapeKind,
                            OverlayHorizontalAlignment = BindingContextPageModel.OverlayHorizontalAlignment,
                            OverlayBackgroundColor = BindingContextPageModel.OverlayBackgroundColor.ToHex(),
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            Title = BindingContextPageModel.Title,
                            TitleFontSize = BindingContextPageModel.TitleFontSize,
                            InfoBlocks = BindingContextPageModel.InfoBlocks.ToArray()
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

        private void AddInfoBlockButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.InfoBlockConfigurationPopupPage(InfoBlockCreation_Callback));
        }

        private void EditInfoBlockButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.InfoBlockConfigurationPopupPage(InfoBlockEdition_Callback, ((sender as Xamarin.Forms.BindableObject).BindingContext as System.ICloneable).Clone() as Templating.Presentation.Models.ContextedMediaInfoBlockModel));
        }

        private void ContextedImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.ContextedImage = selection;
        }

        private void InfoBlockCreation_Callback(Templating.Presentation.Models.ContextedMediaInfoBlockModel model)
        {
            model.Priority = BindingContextPageModel.InfoBlocks.Count;

            BindingContextPageModel.InfoBlocks.Add(model);
        }

        private void InfoBlockEdition_Callback(Templating.Presentation.Models.ContextedMediaInfoBlockModel model)
        {
            var target = BindingContextPageModel.InfoBlocks.First(item => item.Id == model.Id);

            target.Header = model.Header;
            target.HeaderFontSize = model.HeaderFontSize;
            target.IsHeaderVisible = model.IsHeaderVisible;
            target.Content = model.Content;
            target.ContentFontSize = model.ContentFontSize;
            target.ContentMaxLine = model.ContentMaxLine;
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