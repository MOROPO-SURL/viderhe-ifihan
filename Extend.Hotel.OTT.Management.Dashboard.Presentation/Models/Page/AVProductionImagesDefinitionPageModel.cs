namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVProductionImagesDefinitionPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private Xamarin.Forms.ImageSource posterImageSource;
        private Xamarin.Forms.ImageSource placardImageSource;

        public Xamarin.Forms.ImageSource PosterImageSource { get => posterImageSource; set => SetProperty(ref posterImageSource, value); }

        public Xamarin.Forms.ImageSource PlacardImageSource { get => placardImageSource; set => SetProperty(ref placardImageSource, value); }
    }
}
