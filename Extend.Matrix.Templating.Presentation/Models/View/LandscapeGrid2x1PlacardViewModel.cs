namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View
{
    public class LandscapeGrid2x1PlacardViewModel : Contract.AbstractGridPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] BottomCellPlacards { get; set; }

        public bool IsBottomCellPlacardsScalable { get; set; }
    }
}
