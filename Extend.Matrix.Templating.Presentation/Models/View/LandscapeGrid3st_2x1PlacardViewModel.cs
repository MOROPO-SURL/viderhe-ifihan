namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View
{
    public class LandscapeGrid3st_2x1PlacardViewModel : Contract.AbstractGridPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] BottomLeftCellPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] BottomRightCellPlacards { get; set; }
    }
}
