namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context
{
    public class LandscapeGrid3st_2x1PlacardContextModel : Contract.AbstractGridPlacardContextModel
    {
        public object[] TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get; set; }

        public object[] BottomLeftCellPlacards { get; set; }

        public object[] BottomRightCellPlacards { get; set; }
    }
}
