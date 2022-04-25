using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class WebPortalPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.WebPortalPageModel>
    {
        public WebPortalPage(Models.Page.WebPortalPageModel model) : base(model)
        {
            InitializeComponent();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void WebView_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs eventArgs)
        {
            if (!BindingContextPageModel.IsNavigationEnabled)
            {
                eventArgs.Cancel = true;

                return;
            }

            (sender as Xamarin.Forms.WebView).IsEnabled = false;

            BusyView.IsVisible = true;
        }

        private void WebView_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = true;

            BusyView.IsVisible = false;
        }
    }
}