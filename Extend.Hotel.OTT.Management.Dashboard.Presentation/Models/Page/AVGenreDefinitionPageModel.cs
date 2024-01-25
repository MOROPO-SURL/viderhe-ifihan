namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVGenreDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
    }
}
