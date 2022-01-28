namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages.Popup
{
    public partial class CreateScheduledRelaunchPopuoPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private Models.View.PlayerViewModel player;
        private System.Action successCallbackAction;

        public CreateScheduledRelaunchPopuoPage(Models.View.PlayerViewModel player, System.Action successCallbackAction)
        {
            this.player = player;
            this.successCallbackAction = successCallbackAction;

            InitializeComponent();

            BindingContext = new XFToolKit.Mvvm.Models.Page.BasePageModel();
        }

        protected override bool OnBackButtonPressed()
        {
            CancelButton_Clicked(this, System.EventArgs.Empty);

            return true;
        }

        private void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var concreteBindingContext = BindingContext as XFToolKit.Mvvm.Models.Page.BasePageModel;

            concreteBindingContext.IsBusy = true;

            var client = new Cloud.Api.Connect.Clients.ScheduledRelaunchsApiConnectClient(Managers.SessionManager.Instance);

            client.CreateAsync(new Cloud.Api.Common.Models.ScheduledRelaunchInputModel
            {
                PlayerId = player.Id,
                Time = TimePicker.Time
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Cambios aplicados con éxito.");

                        successCallbackAction.Invoke();

                        ReleaseReferences();

                        Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                    }
                    else
                    {
                        concreteBindingContext.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            ReleaseReferences();

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void ReleaseReferences()
        {
            player = null;
            successCallbackAction = null;
        }
    }
}