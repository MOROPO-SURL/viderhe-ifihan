using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Pages
{
    public partial class ServerConectionConfigurationPage : Xamarin.Forms.ContentPage
    {
        public ServerConectionConfigurationPage()
        {
            InitializeComponent();

            APIServerEntry.Text = Managers.SessionManager.Instance.Server;

            IsSSLRequiredSwitch.IsToggled = Managers.SessionManager.Instance.UseSSL;

            IsAnyCertificateAllowedSwitch.IsToggled = Managers.SessionManager.Instance.AllowAnyCertificate;

            TokenEntry.Text = Managers.SessionManager.Instance.APIKeyToken;
        }

        private void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Managers.SessionManager.Instance.ConfigureAsync(APIServerEntry.Text, TokenEntry.Text, IsSSLRequiredSwitch.IsToggled, IsAnyCertificateAllowedSwitch.IsToggled).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        DisplayAlert("Aviso", "No fue posible aplicar los cambios en este momento. Por favor, inténtelo nuevamente.", "Aceptar");
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopModalPageAsync();
                    }
                });
            });
        }

        private void CancelButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}