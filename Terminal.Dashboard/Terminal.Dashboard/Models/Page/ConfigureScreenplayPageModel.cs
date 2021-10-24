namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ConfigureScreenplayPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string title;
        private string about;

        public System.Guid Id { get; set; }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }
    }
}
