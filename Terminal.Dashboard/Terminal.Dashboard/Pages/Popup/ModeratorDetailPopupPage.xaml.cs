namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages.Popup
{
    public partial class ModeratorDetailPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private System.Action<Models.View.ModeratorViewModel> editRequiredActionCallback;
        private System.Action<Models.View.ModeratorViewModel> deleteRequiredActionCallback;

        public ModeratorDetailPopupPage(Models.View.ModeratorViewModel target, System.Action<Models.View.ModeratorViewModel> editRequiredActionCallback, System.Action<Models.View.ModeratorViewModel> deleteRequiredActionCallback = null)
        {
            this.editRequiredActionCallback = editRequiredActionCallback;
            this.deleteRequiredActionCallback = deleteRequiredActionCallback;

            InitializeComponent();

            BindingContext = target;
        }

        private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync().ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    editRequiredActionCallback?.Invoke(BindingContext as Models.View.ModeratorViewModel);

                    ReleaseCallbacks();
                });
            });
        }

        private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync().ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    deleteRequiredActionCallback?.Invoke(BindingContext as Models.View.ModeratorViewModel);

                    ReleaseCallbacks();
                });
            });
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            ReleaseCallbacks();

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void ReleaseCallbacks()
        {
            editRequiredActionCallback = null;
            deleteRequiredActionCallback = null;
        }
    }
}