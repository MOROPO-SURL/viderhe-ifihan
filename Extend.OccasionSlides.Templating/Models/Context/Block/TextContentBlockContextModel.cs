namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block
{
    public class TextContentBlockContextModel : Contract.AbstractContentBlockContextModel
    {
        public string Text { get; set; }

        public int TextMaxLineCount { get; set; }

        public string TextFontFamily { get; set; }

        public int TextFontSize { get; set; }

        public string TextColor { get; set; }
    }
}
