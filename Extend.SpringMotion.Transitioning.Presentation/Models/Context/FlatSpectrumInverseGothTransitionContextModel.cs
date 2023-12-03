using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Enumerations;

namespace MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Models.Context
{
    public class FlatSpectrumInverseGothTransitionContextModel : BaseFlatSpectrumTransitionContextModel
    {
        public FlatSpectrumInverseGothTransitionContextModel()
        {
            HorizontalTransitionOrientation = HorizontalTransitionOrientation.FromRight;
            HorizontalTransitionEasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut;

            VerticalTransitionOrientation = VerticalTransitionOrientation.FromTop;
            VerticalTransitionEasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.Linear;
        }

        public HorizontalTransitionOrientation HorizontalTransitionOrientation { get; set; }

        public VerticalTransitionOrientation VerticalTransitionOrientation { get; set; }

        public SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType HorizontalTransitionEasingType { get; set; }

        public SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType VerticalTransitionEasingType { get; set; }
    }
}
