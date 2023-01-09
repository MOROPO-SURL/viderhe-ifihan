namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractGrid2x2PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Support.Presentation.Models.View.PlacardViewModel[] OneOfFourTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] TwoOfFourTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] ThreeOfFourTargetPlacards { get; set; }

        public Support.Presentation.Models.View.PlacardViewModel[] FourOfFourTargetPlacards { get; set; }
    }
}
