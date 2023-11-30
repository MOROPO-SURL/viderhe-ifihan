using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class AddVideoPageModel : FormPageModel
    {
        private string about;

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        private SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource videoSource;

        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource VideoSource
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
