using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class PersonalityDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private string lastName;
        private string alias;
        private Sex sex;
        private bool hasBornDate;
        private System.DateTime bornDate;
        private Xamarin.Forms.ImageSource imageSource;
        private string about;

        public PersonalityDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string LastName { get => lastName; set => SetProperty(ref lastName, value); }

        public string Alias { get => alias; set => SetProperty(ref alias, value); }

        public Sex Sex { get => sex; set => SetProperty(ref sex, value); }

        public bool HasBornDate { get => hasBornDate; set => SetProperty(ref hasBornDate, value); }

        public System.DateTime BornDate { get => bornDate; set => SetProperty(ref bornDate, value); }

        public Xamarin.Forms.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }
    }
}
