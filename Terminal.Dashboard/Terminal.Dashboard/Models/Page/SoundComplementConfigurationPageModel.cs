using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class SoundComplementConfigurationPageModel : FormPageModel
    {
        private SoundViewModel sound;
        private bool repeat;
        private int delay;

        public SoundViewModel Sound { get => sound; set => SetProperty(ref sound, value); }

        public bool Repeat { get => repeat; set => SetProperty(ref repeat, value); }

        public int Delay { get => delay; set => SetProperty(ref delay, value); }
    }
}
