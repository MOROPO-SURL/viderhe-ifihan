using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ConfigureTextPageModel : FormPageModel
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
