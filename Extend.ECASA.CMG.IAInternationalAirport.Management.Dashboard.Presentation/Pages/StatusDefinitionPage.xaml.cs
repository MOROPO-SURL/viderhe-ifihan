using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Pages
{
    public partial class StatusDefinitionPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.StatusDefinitionPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Action definitionCallbackAction;

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private readonly bool isEditionMode;

        private bool hasChangesFlag;

        public StatusDefinitionPage(System.Action definitionCallbackAction, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.StatusDisplayModel target = null) : base(Factories.StatusDefinitionPageModelFactory.Build(target))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;

            if (target != null)
            {
                isEditionMode = true;
                Title = "Modificar Estado";
            }

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            BindingContextPageModel.IsBusy = true;

            var apiConnectClient = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.StatusesAPIConnectClient(Managers.SessionManager.Instance);

            apiConnectClient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var discriminator = BindingContextPageModel.Discriminator;

                    var currentStateDiscriminators = task.Result.Select(item => item.Discriminator).ToArray();

                    var availableDiscriminators = new System.Collections.Generic.List<int>();

                    for (int i = 0; i <= 15; i++)
                    {
                        if (isEditionMode && i == BindingContextPageModel.Discriminator)
                        {
                            availableDiscriminators.Add(i);

                            continue;
                        }

                        if (currentStateDiscriminators.Contains(i)) continue;

                        availableDiscriminators.Add(i);
                    }

                    BindingContextPageModel.Discriminator = null;

                    BindingContextPageModel.AvailableDiscriminators = availableDiscriminators.ToArray();
                    BindingContextPageModel.Discriminator = discriminator;
                    BindingContextPageModel.IsBusy = false;

                    BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;

                    IsEnabled = true;
                });
            });
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Clicked(this, System.EventArgs.Empty);

            return true;
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                if (!validationBehavior.Target.IsEnabled) continue;

                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            BindingContextPageModel.IsBusy = true;

            var model = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.StatusInputModel
            {
                Id = BindingContextPageModel.Id,
                Label = BindingContextPageModel.Label,
                Discriminator = BindingContextPageModel.Discriminator.Value
            };

            if (BindingContextPageModel.IsEmphasisEnabled)
            {
                model.EmphasisBackgroundColor = BindingContextPageModel.EmphasisBackgroundColor.ToHex();
                model.EmphasisTextColor = BindingContextPageModel.EmphasisTextColor.ToHex();

                if (BindingContextPageModel.IsBlinkAnimationEnabled)
                {
                    model.AlternateBackgroundColor = BindingContextPageModel.AlternateBackgroundColor.ToHex();
                    model.AlternateTextColor = BindingContextPageModel.AlternateTextColor.ToHex();
                }
            }

            var apiConnectClient = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.StatusesAPIConnectClient(Managers.SessionManager.Instance);

            var apiConnectClientTask = isEditionMode ? apiConnectClient.EditAsync(model) : apiConnectClient.CreateAsync(model);

            apiConnectClientTask.ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        definitionCallbackAction.Invoke();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                return;
            }

            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
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