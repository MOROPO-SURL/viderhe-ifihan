namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid2x2PlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public System.Guid[] OneOfFourTargetPlacardIds { get; set; }

        public System.Guid[] TwoOfFourTargetPlacardIds { get; set; }

        public System.Guid[] ThreeOfFourTargetPlacardIds { get; set; }

        public System.Guid[] FourOfFourTargetPlacardIds { get; set; }
    }
}
