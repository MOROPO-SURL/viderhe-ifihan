namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Models.View
{
    public class PrimeOTTHotelTVOverlayViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public Context.OTTHotelTVOverlayContextModel Context { get; set; }

        public Xamarin.Forms.ImageSource ResortInfoActionSplashImageSource { get; set; }

        public Xamarin.Forms.ImageSource HotelServicesActionSplashImageSource { get; set; }

        public Xamarin.Forms.ImageSource VoDActionSplashImageSource { get; set; }

        public Xamarin.Forms.ImageSource ThingsToDoActionSplashImageSource { get; set; }

        public Xamarin.Forms.ImageSource LocalInfoActionSplashImageSource { get; set; }

        public Xamarin.Forms.ImageSource RecomentationsActionSplashImageSource { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ResortInfoActionSplashImageSource = null;
            HotelServicesActionSplashImageSource = null;
            VoDActionSplashImageSource = null;
            ThingsToDoActionSplashImageSource = null;
            LocalInfoActionSplashImageSource = null;
            RecomentationsActionSplashImageSource = null;
        }
    }
}
