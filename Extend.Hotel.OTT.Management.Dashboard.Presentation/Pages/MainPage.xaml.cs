using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class MainPage : Xamarin.Forms.ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChannelsTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ChannelsManagementPage());
        }

        private void ProfilesTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ProfilesManagementPage());
        }
    }
}