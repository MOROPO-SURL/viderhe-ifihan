using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ConfigureScreenplayPageModel : FormPageModel
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
