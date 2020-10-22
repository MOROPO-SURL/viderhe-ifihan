namespace SmartSolucionesCuba.Videre.Extend.Essential.Overlaying.Presentation.Views
{
    public partial class SimpleHighlightsOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public SimpleHighlightsOverlayView(Common.Overlaying.Presentation.Models.View.HighlightsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}