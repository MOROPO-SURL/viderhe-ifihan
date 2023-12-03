using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Pages
{
    public partial class MainPage : Xamarin.Forms.ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ApiKeysTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ApiKeysManagementPage());
        }

        private void RolesTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new RolesManagementPage());
        }

        private void CountriesTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new CountriesManagementPage());
        }

        private void CarriersTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new CarriersManagementPage());
        }

        private void TerminalsTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new TerminalsManagementPage());
        }

        private void StatusesTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new StatusesManagementPage());
        }

        private void CategoriesTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new CategoriesManagementPage());
        }

        private void KindsTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new KindsManagementPage());
        }
    }
}