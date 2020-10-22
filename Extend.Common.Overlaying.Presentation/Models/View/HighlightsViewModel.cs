namespace SmartSolucionesCuba.Videre.Extend.Common.Overlaying.Presentation.Models.View
{
    public class HighlightsViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
