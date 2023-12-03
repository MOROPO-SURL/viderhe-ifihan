using MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Enumerations;

namespace MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Models.Context
{
    public class FlatBoxMatrixSweptCurtainTransitionContextModel
    {
        public Xamarin.Forms.Color Color { get; set; }

        public SweptTransitionOrientation Orientation { get; set; }

        public SweptTransitionInOutKind InOutKind { get; set; }

        public SweptTransitionItemMotionType MotionType { get; set; }

        public SweptTransitionItemMotionMode MotionMode { get; set; }
    }
}
