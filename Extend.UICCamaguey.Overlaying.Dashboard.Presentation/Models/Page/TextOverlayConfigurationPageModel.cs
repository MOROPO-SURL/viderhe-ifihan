namespace MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Models.Page
{
    public class TextOverlayConfigurationPageModel : AbstractOverlayConfigurationPageModel
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }
    }
}
