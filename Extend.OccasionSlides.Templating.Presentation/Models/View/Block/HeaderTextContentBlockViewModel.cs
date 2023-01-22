namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class HeaderTextContentBlockViewModel : TextContentBlockViewModel
    {
        private string header;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string HeaderFontFamily { get; set; }

        public int HeaderFontSize { get; set; }

        public Xamarin.Forms.Color HeaderColor { get; set; }
    }
}
