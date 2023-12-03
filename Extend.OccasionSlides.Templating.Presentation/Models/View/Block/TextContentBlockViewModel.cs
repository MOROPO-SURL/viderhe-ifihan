namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class TextContentBlockViewModel : Contract.AbstractContentBlockViewModel
    {
        private string text;

        public string Text { get => text; set => SetProperty(ref text, value); }

        public int TextMaxLineCount { get; set; }

        public string TextFontFamily { get; set; }

        public int TextFontSize { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }
    }
}
