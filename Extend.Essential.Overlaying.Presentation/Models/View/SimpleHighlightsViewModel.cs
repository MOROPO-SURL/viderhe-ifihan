namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Presentation.Models.View
{
    public class SimpleHighlightsViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
