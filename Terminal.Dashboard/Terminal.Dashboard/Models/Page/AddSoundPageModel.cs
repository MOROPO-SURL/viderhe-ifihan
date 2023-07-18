namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class AddSoundPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string about;

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        private XFToolKit.Presentation.Sources.Video.VideoSource audioSource;

        public XFToolKit.Presentation.Sources.Video.VideoSource AudioSource
        {
            get => audioSource;
            set => SetProperty(ref audioSource, value);
        }

        public string Format { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            AudioSource = null;
        }
    }
}
