namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid2x2PlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public object[] OneOfFourTargetPlacards { get; set; }

        public object[] TwoOfFourTargetPlacards { get; set; }

        public object[] ThreeOfFourTargetPlacards { get; set; }

        public object[] FourOfFourTargetPlacards { get; set; }
    }
}
