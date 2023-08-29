using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
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

        private void ChannelsTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ChannelsManagementPage());
        }

        private void ProfilesTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ProfilesManagementPage());
        }
    }
}