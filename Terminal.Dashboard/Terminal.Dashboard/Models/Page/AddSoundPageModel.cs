using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class AddSoundPageModel : FormPageModel
    {
        private string about;

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        private SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource audioSource;

        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource AudioSource
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
