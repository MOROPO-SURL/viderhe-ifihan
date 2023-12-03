using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Enumerations;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Pages
{
    public partial class HeroLocalNowDateTimePlacardConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<HeroLocalNowDateTimePlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private const string BACKGROUND_OPTION_SOLID = "Color Sólido";
        private const string BACKGROUND_OPTION_GRADIENT = "Gradiente";
        private const string BACKGROUND_OPTION_IMAGE = "Imagen";
        private const string BACKGROUND_OPTION_VIDEO = "Video";

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public HeroLocalNowDateTimePlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public HeroLocalNowDateTimePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(HeroLocalNowDateTimePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.HeroLocalNowDateTimeTemplateDescriptor();

                Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);
            }
            else
            {
                Title = string.Format("Modificando Cartel ({0})", placardViewModel.Template.Name);
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
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
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = HeroLocalNowDateTimeTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            Style = BindingContextPageModel.Style,
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            TextFontFamily = BindingContextPageModel.TextFontFamily,
                            IsDateTimeFramed = BindingContextPageModel.IsDateTimeFramed,
                            Culture = BindingContextPageModel.AvailableCultures[BindingContextPageModel.CultureIndex],
                            Background = BindingContextPageModel.Background
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
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Id = placardViewModel.Id,
                        Label = BindingContextPageModel.Label,
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            Style = BindingContextPageModel.Style,
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            TextFontFamily = BindingContextPageModel.TextFontFamily,
                            IsDateTimeFramed = BindingContextPageModel.IsDateTimeFramed,
                            Culture = BindingContextPageModel.AvailableCultures[BindingContextPageModel.CultureIndex],
                            Background = BindingContextPageModel.Background
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
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Aviso", "Cambios aplicados con éxito.");

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

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(Cloud.Persistence.Enumerations.TagGroup.Placard, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este cartel?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as Cloud.Api.Common.Models.TagDisplayModel));
            });
        }

        private void PickTagSuccess_Callback(Cloud.Api.Common.Models.TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private void BackgroundGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            DisplayActionSheet("Seleccione el tipo de fondo a definir:", "Cancelar", null, new string[] { BACKGROUND_OPTION_SOLID, BACKGROUND_OPTION_GRADIENT, BACKGROUND_OPTION_IMAGE }).ContinueWith(displayActionSheetTask =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    switch (displayActionSheetTask.Result)
                    {
                        case BACKGROUND_OPTION_SOLID:
                            var color = await Xam.Plugin.SimpleColorPicker.ColorPickerDialog.Show(Content as Xamarin.Forms.Layout<Xamarin.Forms.View>, "Defina el color a utilizar como fondo:", Xamarin.Forms.Color.Accent);

                            BindingContextPageModel.Background = new Templating.Models.Context.BackgroundContextModel
                            {
                                Kind = BackgroundKind.Solid,
                                SerializedContext = color?.ToHex()
                            };

                            break;

                        case BACKGROUND_OPTION_IMAGE:
                            Support.Presentation.Models.View.ImageViewModel except = null;

                            if (BindingContextPageModel.Background != null && BindingContextPageModel.Background.Kind == BackgroundKind.Image)
                            {
                                except = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(BindingContextPageModel.Background.SerializedContext).ToViewModel();
                            }

                            var imagePickPage = new Support.Presentation.Dashboard.Pages.ImagePickPage(BackgroundImagePick_Callback, except);

                            await this.NavigationPushPageAsync(imagePickPage);

                            break;

                        case BACKGROUND_OPTION_GRADIENT:
                            await this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.GradientPickPage(BackgroundGradientPick_Callback));

                            break;
                    }
                });                
            });
        }

        private void TextFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.TextFontFamily = null;
        }

        private void TextFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(TextFontFamilyPicked_Callback));
        }

        private void TextFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.TextFontFamily = selection;
        }

        private void BackgroundImagePick_Callback(Support.Presentation.Models.View.ImageViewModel target)
        {
            BindingContextPageModel.Background = new Templating.Models.Context.BackgroundContextModel
            {
                Kind = BackgroundKind.Image,
                SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(target.ToContextModel())
            };
        }

        private void BackgroundGradientPick_Callback(Support.Presentation.Dashboard.Models.View.GradientViewModel target)
        {
            BindingContextPageModel.Background = new Templating.Models.Context.BackgroundContextModel
            {
                Kind = BackgroundKind.Gradient,
                SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Common.Templating.Models.Context.GradientContextModel
                {
                    Id = target.Id,
                    About = target.About,
                    CreateAt = target.CreateAt,
                    Data = target.Source.Stylesheet
                })
            };
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
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