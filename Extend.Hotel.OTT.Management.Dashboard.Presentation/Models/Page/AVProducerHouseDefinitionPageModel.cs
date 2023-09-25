namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVProducerHouseDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private bool hasBornDate;
        private System.DateTime bornDate;
        private Xamarin.Forms.ImageSource imageSource;
        private string about;

        public AVProducerHouseDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public bool HasBornDate { get => hasBornDate; set => SetProperty(ref hasBornDate, value); }

        public System.DateTime BornDate { get => bornDate; set => SetProperty(ref bornDate, value); }

        public Xamarin.Forms.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }
    }
}
