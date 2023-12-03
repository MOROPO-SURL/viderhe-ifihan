using MOROPO.VIDERHE.Support.Extend.Overlaying.Providers;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class AccountIdentityConfigurationPageModel : FormPageModel
    {
        private string name;
        private Xamarin.Forms.ImageSource logoImageSource;
        private Xamarin.Forms.ImageSource horizontalSplashImageSource;
        private Xamarin.Forms.ImageSource verticalSplashImageSource;
        private Xamarin.Forms.Color primaryColor;
        private Xamarin.Forms.Color secoundaryColor;
        private Extend.Common.Overlaying.Descriptors.IOverlayDescriptor defaultOverlay;
        private string serializedOverlayContext;

        public AccountIdentityConfigurationPageModel()
        {
            AvailableOverlays = OverlayDescriptorProvider.Instance.GetDescriptors();
        }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public Xamarin.Forms.ImageSource LogoImageSource { get => logoImageSource; set => SetProperty(ref logoImageSource, value); }

        public Xamarin.Forms.ImageSource HorizontalSplashImageSource { get => horizontalSplashImageSource; set => SetProperty(ref horizontalSplashImageSource, value); }

        public Xamarin.Forms.ImageSource VerticalSplashImageSource { get => verticalSplashImageSource; set => SetProperty(ref verticalSplashImageSource, value); }

        public Xamarin.Forms.Color PrimaryColor { get => primaryColor; set => SetProperty(ref primaryColor, value); }

        public Xamarin.Forms.Color SecoundaryColor { get => secoundaryColor; set => SetProperty(ref secoundaryColor, value); }

        public Extend.Common.Overlaying.Descriptors.IOverlayDescriptor DefaultOverlay { get => defaultOverlay; set => SetProperty(ref defaultOverlay, value); }

        public string SerializedOverlayContext { get => serializedOverlayContext; set => SetProperty(ref serializedOverlayContext, value); }

        public Extend.Common.Overlaying.Descriptors.IOverlayDescriptor[] AvailableOverlays { get; set; }
    }
}
