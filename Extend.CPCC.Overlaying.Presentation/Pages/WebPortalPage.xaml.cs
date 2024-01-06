using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class WebPortalPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<WebPortalPageModel>
    {
        public WebPortalPage(WebPortalPageModel model) : base(model)
        {
            InitializeComponent();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
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