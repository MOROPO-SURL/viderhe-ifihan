namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ConfigureTextPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string about;
        private string content;

        public System.Guid Id { get; set; }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public string Content { get => content; set => SetProperty(ref content, value); }
    }
}
