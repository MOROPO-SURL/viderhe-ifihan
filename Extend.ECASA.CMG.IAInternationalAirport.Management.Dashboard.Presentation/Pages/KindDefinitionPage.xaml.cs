using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Managers;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Pages
{
    public partial class KindDefinitionPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<KindDefinitionPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Action definitionCallbackAction;

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private readonly bool isEditionMode;

        private bool hasChangesFlag;

        public KindDefinitionPage(System.Action definitionCallbackAction, Service.ECASA.CMG.InterFIDS.API.Common.Models.KindDisplayModel target = null) : base(KindDefinitionPageModelFactory.Build(target))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;

            if (target != null)
            {
                isEditionMode = true;
                Title = "Modificar Tipo de Operación";

                BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;

                return;
            }

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            BindingContextPageModel.IsBusy = true;

            var apiConnectClient = new Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.KindsAPIConnectClient(SessionManager.Instance);

            apiConnectClient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        this.NavigationPopPageAsync().ContinueWith(_ =>
                        {
                            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                            {
                                Helpers.SharedExceptionHandleHelper.Instance.HandleException(task.Exception);
                            });
                        });

                        return;
                    }

                    var usedOperationKinds = task.Result.Select(item => item.Id).ToArray();

                    var allOperationKinds = new Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind[]
                    {
                        Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival,
                        Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                    };

                    BindingContextPageModel.AvailableIds = allOperationKinds.Except(usedOperationKinds).ToArray();
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

            var model = new Service.ECASA.CMG.InterFIDS.API.Common.Models.KindInputModel
            {
                Id = BindingContextPageModel.Id.Value,
                Discriminator = BindingContextPageModel.Discriminator
            };

            var apiConnectClient = new Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.KindsAPIConnectClient(SessionManager.Instance);

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

                        Helpers.SharedExceptionHandleHelper.Instance.HandleException(task.Exception);
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