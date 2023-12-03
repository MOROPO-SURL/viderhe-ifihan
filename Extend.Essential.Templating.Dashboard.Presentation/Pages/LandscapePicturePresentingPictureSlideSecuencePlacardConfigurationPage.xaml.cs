using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPageModel>, IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPage(PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor();

                Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Cartel ({0})", placardViewModel.Template.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    var model = new PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapePicturePresentingPictureSlideSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterImage = BindingContextPageModel.PresenterImage.ToContextModel(),
                            PresenterSide = BindingContextPageModel.PresenterSide,
                            PresentedPictureSlideSecuence = new Templating.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Templating.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            },
                            PresentedPictureSlideSecuenceCenteredAtPresentation = BindingContextPageModel.PresentedPictureSlideSecuenceCenteredAtPresentation
                        }),
                        Tags = BindingContextPageModel.Tags.ToArray()
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
                }
                else
                {
                    var model = new PlacardInputModel
                    {
                        Id = placardViewModel.Id,
                        Label = BindingContextPageModel.Label,
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapePicturePresentingPictureSlideSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterImage = BindingContextPageModel.PresenterImage.ToContextModel(),
                            PresenterSide = BindingContextPageModel.PresenterSide,
                            PresentedPictureSlideSecuence = new Templating.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Templating.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            },
                            PresentedPictureSlideSecuenceCenteredAtPresentation = BindingContextPageModel.PresentedPictureSlideSecuenceCenteredAtPresentation
                        }),
                        Tags = BindingContextPageModel.Tags.ToArray()
                    };

                    if (BindingContextPageModel.DefineBeginAt)
                    {
                        model.BeginAt = BindingContextPageModel.BeginAt;
                    }

                    if (BindingContextPageModel.DefineEndAt)
                    {
                        model.EndAt = BindingContextPageModel.EndAt;
                    }

                    await client.EditAsync(model);
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

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
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(PresenterImagePicked_Callback, BindingContextPageModel.PresenterImage));
        }

        private void PresenterImagePicked_Callback(ImageViewModel selection)
        {
            BindingContextPageModel.PresenterImage = selection;
        }

        private void IncludeImagesButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagesPickPage(BindingContextPageModel.PresentedSlides.Select(item => item.Image).ToArray(), ImagesSelected_Callback));
        }

        private void ImageDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta imagen de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var slide = (sender as Xamarin.Forms.BindableObject).BindingContext as PictureSlideViewModel;

                    BindingContextPageModel.PresentedSlides.Remove(slide);
                });
            });
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(TagGroup.Placard, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este cartel?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as TagDisplayModel));
            });
        }

        private void PickTagSuccess_Callback(TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private void ImagesSelected_Callback(ImageViewModel[] selection)
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
            successfulCompleteCallbackAction = null;
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void AddValidationMessage(string label, string message)
        {
            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label,
                Message = message
            });
        }

        #endregion
    }
}