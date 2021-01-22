namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class AddVideoPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string about;

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        private XFToolKit.Presentation.Sources.Video.VideoSource videoSource;

        public XFToolKit.Presentation.Sources.Video.VideoSource VideoSource
        {
            get => videoSource;
            set => SetProperty(ref videoSource, value);
        }

        public string Format { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            VideoSource = null;
        }
    }
}
