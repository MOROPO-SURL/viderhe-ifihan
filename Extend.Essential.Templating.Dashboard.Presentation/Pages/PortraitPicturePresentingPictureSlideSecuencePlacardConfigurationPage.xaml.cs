using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel>
    {
        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;
        private Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter;
        private System.Action successfulCompleteCallbackAction;

        public PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPage(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : this(null, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, successfulCompleteCallbackAction)
        {
        }

        public PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, System.Action successfulCompleteCallbackAction)
            : base(Factories.PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;
            this.notificationPresenter = notificationPresenter;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor();

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
                        TemplateId = Descriptors.PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.PortraitPicturePresentingPictureSlideSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterImage = BindingContextPageModel.PresenterImage.ToContextModel(),
                            PresenterSide = BindingContextPageModel.PresenterSide,
                            PresentedPictureSlideSecuence = new Templating.Presentation.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Templating.Presentation.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Presentation.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            },
                            PresentedPictureSlideSecuenceCenteredAtPresentation = BindingContextPageModel.PresentedPictureSlideSecuenceCenteredAtPresentation
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.PortraitPicturePresentingPictureSlideSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterImage = BindingContextPageModel.PresenterImage.ToContextModel(),
                            PresenterSide = BindingContextPageModel.PresenterSide,
                            PresentedPictureSlideSecuence = new Templating.Presentation.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Templating.Presentation.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Presentation.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            },
                            PresentedPictureSlideSecuenceCenteredAtPresentation = BindingContextPageModel.PresentedPictureSlideSecuenceCenteredAtPresentation
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

        private void PickPresenterImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(exceptionHandleHelper, httpClientHelperProvider, PresenterImagePicked_Callback, BindingContextPageModel.PresenterImage));
        }

        private void PresenterImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.PresenterImage = selection;
        }

        private void IncludeImagesButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagesPickPage(BindingContextPageModel.PresentedSlides.Select(item => item.Image).ToArray(), exceptionHandleHelper, httpClientHelperProvider, ImagesSelected_Callback));
        }

        private void ImageDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta imagen de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var slide = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.PictureSlideViewModel;

                    BindingContextPageModel.PresentedSlides.Remove(slide);
                });
            });
        }

        private void ImagesSelected_Callback(Support.Presentation.Models.View.ImageViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.PresentedSlides.Add(new Models.View.PictureSlideViewModel { Image = item });
            }
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