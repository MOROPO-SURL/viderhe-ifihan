namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class AccountIdentityConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string name;
        private Xamarin.Forms.ImageSource logoImageSource;
        private Xamarin.Forms.ImageSource splashImageSource;
        private Xamarin.Forms.Color primaryColor;
        private Xamarin.Forms.Color secoundaryColor;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public Xamarin.Forms.ImageSource LogoImageSource { get => logoImageSource; set => SetProperty(ref logoImageSource, value); }
        public Xamarin.Forms.ImageSource SplashImageSource { get => splashImageSource; set => SetProperty(ref splashImageSource, value); }
        public Xamarin.Forms.Color PrimaryColor { get => primaryColor; set => SetProperty(ref primaryColor, value); }
        public Xamarin.Forms.Color SecoundaryColor { get => secoundaryColor; set => SetProperty(ref secoundaryColor, value); }
    }
}
