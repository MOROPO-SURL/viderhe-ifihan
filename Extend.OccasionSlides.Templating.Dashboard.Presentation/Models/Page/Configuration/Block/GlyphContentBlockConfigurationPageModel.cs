namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class GlyphContentBlockConfigurationPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string glyph;
        private int fontSize;
        private Xamarin.Forms.Color color;

        public GlyphContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            fontSize = 60;
        }

        public System.Guid Id { get; set; }

        public string Glyph { get => glyph; set => SetProperty(ref glyph, value); }

        public int FontSize { get => fontSize; set => SetProperty(ref fontSize, value); }

        public Xamarin.Forms.Color Color { get => color; set => color = value; }
    }
}
