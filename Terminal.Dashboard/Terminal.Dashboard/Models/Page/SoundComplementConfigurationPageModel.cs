namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class SoundComplementConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private Support.Presentation.Models.View.SoundViewModel sound;
        private bool repeat;
        private int delay;

        public Support.Presentation.Models.View.SoundViewModel Sound { get => sound; set => SetProperty(ref sound, value); }

        public bool Repeat { get => repeat; set => SetProperty(ref repeat, value); }

        public int Delay { get => delay; set => SetProperty(ref delay, value); }
    }
}
