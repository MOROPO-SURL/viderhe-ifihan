namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid1x3PlacardContextModel
    {
        public System.Guid OneOfThreeTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind OneOfThreeTargetKind { get; set; }

        public System.Guid TwoOfThreeTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind TwoOfThreeTargetKind { get; set; }

        public System.Guid ThreeOfThreeTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind ThreeOfThreeTargetKind { get; set; }
    }
}
