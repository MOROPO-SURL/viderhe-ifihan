using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Pages
{
    public partial class ClassicArraivalsPlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ClassicOperationsPlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public ClassicArraivalsPlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public ClassicArraivalsPlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.ClassicOperationsPlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.ClassicArraivalsTemplateDescriptor();

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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.ClassicArraivalsTemplateDescriptor.ID,
                        PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            APIServer = BindingContextPageModel.APIServer,
                            UseSSL = BindingContextPageModel.UseSSL,
                            APIKey = BindingContextPageModel.APIKey,
                            AllowAnyCertificate = BindingContextPageModel.AllowAnyCertificate,
                            UpdateInterval = BindingContextPageModel.UpdateInterval,
                            MaxItemsCount = BindingContextPageModel.MaxItemsCount,
                            BackgroundColor = BindingContextPageModel.BackgroundColor.ToHex(),
                            TableHeaderTextColor = BindingContextPageModel.TableHeaderTextColor.ToHex(),
                            TableHeaderBackgroundColor = BindingContextPageModel.TableHeaderBackgroundColor.ToHex(),
                            TableHeaderFontSize = BindingContextPageModel.TableHeaderFontSize,
                            PrimaryRowTextColor = BindingContextPageModel.PrimaryRowTextColor.ToHex(),
                            PrimaryRowBackgroundColor = BindingContextPageModel.PrimaryRowBackgroundColor.ToHex(),
                            UseStrippedRows = BindingContextPageModel.UseStrippedRows,
                            SecoundaryRowTextColor = BindingContextPageModel.SecoundaryRowTextColor.ToHex(),
                            SecoundaryRowBackgroundColor = BindingContextPageModel.SecoundaryRowBackgroundColor.ToHex(),
                            RowFontSize = BindingContextPageModel.RowFontSize,
                            Columns = BindingContextPageModel.Columns.ToArray()
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
                        PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            APIServer = BindingContextPageModel.APIServer,
                            UseSSL = BindingContextPageModel.UseSSL,
                            APIKey = BindingContextPageModel.APIKey,
                            AllowAnyCertificate = BindingContextPageModel.AllowAnyCertificate,
                            UpdateInterval = BindingContextPageModel.UpdateInterval,
                            MaxItemsCount = BindingContextPageModel.MaxItemsCount,
                            BackgroundColor = BindingContextPageModel.BackgroundColor.ToHex(),
                            TableHeaderTextColor = BindingContextPageModel.TableHeaderTextColor.ToHex(),
                            TableHeaderBackgroundColor = BindingContextPageModel.TableHeaderBackgroundColor.ToHex(),
                            TableHeaderFontSize = BindingContextPageModel.TableHeaderFontSize,
                            PrimaryRowTextColor = BindingContextPageModel.PrimaryRowTextColor.ToHex(),
                            PrimaryRowBackgroundColor = BindingContextPageModel.PrimaryRowBackgroundColor.ToHex(),
                            UseStrippedRows = BindingContextPageModel.UseStrippedRows,
                            SecoundaryRowTextColor = BindingContextPageModel.SecoundaryRowTextColor.ToHex(),
                            SecoundaryRowBackgroundColor = BindingContextPageModel.SecoundaryRowBackgroundColor.ToHex(),
                            RowFontSize = BindingContextPageModel.RowFontSize,
                            Columns = BindingContextPageModel.Columns.ToArray()
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

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
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