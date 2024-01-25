namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page
{
    public class ChannelDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private bool enabled;
        private Service.Hotel.OTT.Persistence.Enumerations.ChannelKind kind;
        private int? radioFrecuencyBand;
        private string iPTVUrl;
        private Xamarin.Forms.ImageSource featureImageSource;
        private string description;

        public ChannelDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public bool Enabled { get => enabled; set => SetProperty(ref enabled, value); }

        public Service.Hotel.OTT.Persistence.Enumerations.ChannelKind Kind { get => kind; set => SetProperty(ref kind, value); }

        public int? RadioFrecuencyBand { get => radioFrecuencyBand; set => SetProperty(ref radioFrecuencyBand, value); }

        public string IPTVUrl { get => iPTVUrl; set => SetProperty(ref iPTVUrl, value); }

        public Xamarin.Forms.ImageSource FeatureImageSource { get => featureImageSource; set => SetProperty(ref featureImageSource, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.Guid? FeatureImageId { get; set; }

        public string FeatureImageExtension { get; set; }
    }
}
