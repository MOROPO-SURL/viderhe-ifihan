namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Views
{
    public partial class ConfigurationStepStartingDetailView : XFToolKit.Mvvm.Views.ContentView
    {
        public ConfigurationStepStartingDetailView()
        {
            InitializeComponent();

            PresentServerAddress();
        }

        public void PresentFallbackOptions()
        {
            FallbackOptionsLayout.IsVisible = true;
        }

        private void ChangeServerButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Xamarin.Forms.Application.Current.MainPage.DisplayPromptAsync("Nombre del Servidor", "Especifique la dirección de red del servidor Viderhe Cloud:", "Aceptar", "Cancelar", "Ej. cloud.viderhe.net o 192.168.0.2").ContinueWith(task =>
            {
                Support.Presentation.Managers.SessionMemoryManager.Instance.Server = task.Result;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentServerAddress);
            });
        }

        private void OpenSystemSettingsButton_Clicked(object sender, System.EventArgs eventArgs) 
        {
            Xamarin.Forms.DependencyService.Get<Helpers.Facade.IPlatformControlHelperFacade>().OpenSystemSettings();
        }

        private void PresentServerAddress()
        {
            ServerAddressLabel.Text = Support.Presentation.Managers.SessionMemoryManager.Instance.Server;
        }
    }
}