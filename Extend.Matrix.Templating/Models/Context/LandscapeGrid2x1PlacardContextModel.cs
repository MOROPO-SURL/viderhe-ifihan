namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context
{
    public class LandscapeGrid2x1PlacardContextModel : Contract.AbstractGridPlacardContextModel
    {
        public object[] TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get; set; }

        public object[] BottomCellPlacards { get; set; }

        public bool IsBottomCellPlacardsScalable { get; set; }
    }
}
