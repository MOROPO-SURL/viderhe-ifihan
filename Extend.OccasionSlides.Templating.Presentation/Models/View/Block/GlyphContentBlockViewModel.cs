namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class GlyphContentBlockViewModel : Contract.AbstractContentBlockViewModel
    {
        private string glyph;

        public string Glyph { get => glyph; set => SetProperty(ref glyph, value); }

        public int FontSize { get; set; }

        public Xamarin.Forms.Color Color { get; set; }
    }
}
