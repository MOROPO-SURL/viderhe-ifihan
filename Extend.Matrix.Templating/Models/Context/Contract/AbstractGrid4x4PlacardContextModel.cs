namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Models.Context.Contract
{
    public abstract class AbstractGrid4x4PlacardContextModel
    {
        public System.Guid OneOfFourTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind OneOfFourTargetKind { get; set; }

        public System.Guid TwoOfFourTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind TwoOfFourTargetKind { get; set; }

        public System.Guid ThreeOfFourTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind ThreeOfFourTargetKind { get; set; }

        public System.Guid FourOfFourTargetId { get; set; }

        public Enumerations.MatrixItemTargetKind FourOfFourTargetKind { get; set; }
    }
}
