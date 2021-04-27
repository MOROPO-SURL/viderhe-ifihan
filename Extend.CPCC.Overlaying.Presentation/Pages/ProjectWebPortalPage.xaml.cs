using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class ProjectWebPortalPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        public ProjectWebPortalPage()
        {
            InitializeComponent();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }

        private void WebView_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs eventArgs)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = false;

            NavigationActivityIndicator.IsRunning = true;
        }

        private void WebView_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = true;

            NavigationActivityIndicator.IsRunning = false;
        }
    }
}