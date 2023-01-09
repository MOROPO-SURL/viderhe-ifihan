namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractGrid1x3PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] OneOfThreeTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] TwoOfThreeTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] ThreeOfThreeTargetPlacards { get; set; }
    }
}
