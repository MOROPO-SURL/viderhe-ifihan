using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class CountryDefinitionPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.CountryDefinitionPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Action definitionCallbackAction;

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private readonly bool isEditionMode;

        private bool hasChangesFlag;

        public CountryDefinitionPage(System.Action definitionCallbackAction, MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.CountryDisplayModel target = null) : base(Factories.CountryDefinitionPageModelFactory.Build(target))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;

            BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;

            if (target != null)
            {
                isEditionMode = true;
                Title = "Modificar País";
            }
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

            var model = new MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.CountryInputModel
            {
                Id = BindingContextPageModel.Id,
                Name = BindingContextPageModel.Name,
                IsoCode = BindingContextPageModel.IsoCode
            };

            var apiConnectClient = new MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients.CountriesAPIConnectClient(Managers.SessionManager.Instance);

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