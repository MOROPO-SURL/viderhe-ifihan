using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Pages
{
    public partial class HeroLocalNowDateTimePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.HeroLocalNowDateTimePlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private const string BACKGROUND_OPTION_SOLID = "Color Sólido";
        private const string BACKGROUND_OPTION_GRADIENT_GALLERY = "Gradiente Prediseñado";
        private const string BACKGROUND_OPTION_GRADIENT_CUSTOM = "Gradiente Personalizado";
        private const string BACKGROUND_OPTION_GRADIENT_IMAGE = "Imagen";
        private const string BACKGROUND_OPTION_GRADIENT_VIDEO = "Video";

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public HeroLocalNowDateTimePlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public HeroLocalNowDateTimePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.HeroLocalNowDateTimePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.HeroLocalNowDateTimeTemplateDescriptor();

                Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);
            }
            else
            {
                Title = string.Format("Modificando Marco ({0})", placardViewModel.Template.Name);
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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    await client.CreateAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.RssFeedCollageHeroTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            Style = BindingContextPageModel.Style,
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            IsDateTimeFramed = BindingContextPageModel.IsDateTimeFramed,
                            Culture = BindingContextPageModel.Culture,
                            Background = BindingContextPageModel.Background
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            Style = BindingContextPageModel.Style,
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            IsDateTimeFramed = BindingContextPageModel.IsDateTimeFramed,
                            Culture = BindingContextPageModel.Culture,
                            Background = BindingContextPageModel.Background
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

        private void BackgroundGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            DisplayActionSheet("Seleccione el tipo de fondo a definir:", "Cancelar", null, new string[] { BACKGROUND_OPTION_SOLID, BACKGROUND_OPTION_GRADIENT_GALLERY, BACKGROUND_OPTION_GRADIENT_IMAGE }).ContinueWith(displayActionSheetTask =>
            {
                
            });
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