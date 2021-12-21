using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ConfigureScreenplayPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ConfigureScreenplayPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private readonly bool editionMode;

        private System.Action completedCallackAction;

        public ConfigureScreenplayPage(System.Action completedCallackAction, Models.View.ScreenplayViewModel model = null)
            : base(Factories.ConfigureScreenplayPageModelFactory.Build(model))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            editionMode = model != null;

            this.completedCallackAction = completedCallackAction;

            if (editionMode)
            {
                Title = "Modificar Guion";
            }
            else
            {
                Title = "Agregar Guion";
            }
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Activated(this, System.EventArgs.Empty);

            return true;
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
            });
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs eventArgs)
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
                var client = new Cloud.Api.Connect.Clients.ScreenplaysApiConnectClient(Managers.SessionManager.Instance);

                if (editionMode)
                {
                    await client.EditAsync(new Cloud.Api.Common.Models.ScreenplayInputModel
                    {
                        Id = BindingContextPageModel.Id,
                        Title = BindingContextPageModel.Title,
                        About = BindingContextPageModel.About
                    });
                }
                else
                {
                    await client.CreateAsync(new Cloud.Api.Common.Models.ScreenplayInputModel
                    {
                        Title = BindingContextPageModel.Title,
                        About = BindingContextPageModel.About
                    });
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        completedCallackAction.Invoke();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            completedCallackAction = null;
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