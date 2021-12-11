namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class HelpPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            MainWebView.Source = new Xamarin.Forms.UrlWebViewSource { Url = string.Format("http://{0}/support", Support.Presentation.Managers.SessionMemoryManager.Instance.Server) };
        }
    }
}