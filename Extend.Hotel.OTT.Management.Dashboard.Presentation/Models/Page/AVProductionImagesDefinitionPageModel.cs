namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVProductionImagesDefinitionPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private Xamarin.Forms.ImageSource posterImageSource;
        private Xamarin.Forms.ImageSource placardImageSource;

        public System.Guid Id { get; set; }

        public Xamarin.Forms.ImageSource PosterImageSource { get => posterImageSource; set => SetProperty(ref posterImageSource, value); }

        public System.Guid? PosterImageId { get; set; }

        public string PosterImageExtension { get; set; }

        public Xamarin.Forms.ImageSource PlacardImageSource { get => placardImageSource; set => SetProperty(ref placardImageSource, value); }

        public System.Guid? PlacardImageId { get; set; }

        public string PlacardImageExtension { get; set; }
    }
}
