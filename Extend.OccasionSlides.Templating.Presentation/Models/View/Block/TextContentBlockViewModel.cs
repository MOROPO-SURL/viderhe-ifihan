namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class TextContentBlockViewModel : Contract.AbstractContentBlockViewModel
    {
        public string Text { get; set; }

        public int TextMaxLineCount { get; set; }

        public string TextFontFamily { get; set; }

        public int TextFontSize { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }
    }
}
