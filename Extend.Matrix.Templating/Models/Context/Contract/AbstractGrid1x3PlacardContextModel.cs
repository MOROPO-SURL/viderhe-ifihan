namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid1x3PlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public System.Guid[] OneOfThreeTargetPlacardIds { get; set; }

        public System.Guid[] TwoOfThreeTargetPlacardIds { get; set; }

        public System.Guid[] ThreeOfThreeTargetPlacardIds { get; set; }
    }
}
