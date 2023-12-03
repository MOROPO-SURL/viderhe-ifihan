namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Presentation.Models.View
{
    public class SimpleHighlightsViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string header;
        private string highlights;

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string Highlights { get => highlights; set => SetProperty(ref highlights, value); }
    }
}
