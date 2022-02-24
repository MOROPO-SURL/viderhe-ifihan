using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Pages
{
    public partial class InformationContentPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        public InformationContentPage(string title, string url)
        {
            InitializeComponent();

            IsEnabled = false;

            InformationTitleLabel.Text = title;

            InformationContentWebView.Source = new Xamarin.Forms.UrlWebViewSource { Url = url };
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void WebView_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs eventArgs)
        {
            if (!IsEnabled)
            {
                (sender as Xamarin.Forms.WebView).IsEnabled = false;

                BusyView.IsVisible = true;

                IsEnabled = true;

                return;
            }

            eventArgs.Cancel = true;
        }

        private void WebView_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = true;

            BusyView.IsVisible = false;
        }
    }
}