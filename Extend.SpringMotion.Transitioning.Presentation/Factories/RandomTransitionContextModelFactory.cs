using MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Models.Context;

namespace MOROPO.VIDERHE.Extend.SpringMotion.Transitioning.Presentation.Factories
{
    public static class RandomTransitionContextModelFactory
    {
        public static FlatBoxMatrixSweptCurtainTransitionContextModel CreateFlatBoxMatrixSweptCurtainTransitionContextModel(Xamarin.Forms.Color color)
        {
            var randomizer = new System.Random();

            var motionTypeCount = System.Enum.GetNames(typeof(SweptTransitionItemMotionType)).Length;
            //var motionModeCount = System.Enum.GetNames(typeof(Enumerations.SweptTransitionItemMotionMode)).Length;
            var orientationCount = System.Enum.GetNames(typeof(SweptTransitionOrientation)).Length;
            var inOutKindCount = System.Enum.GetNames(typeof(SweptTransitionInOutKind)).Length;

            return new FlatBoxMatrixSweptCurtainTransitionContextModel
            {
                Color = color,
                MotionType = (SweptTransitionItemMotionType)randomizer.Next(0, motionTypeCount),
                MotionMode = SweptTransitionItemMotionMode.Quick,//(Enumerations.SweptTransitionItemMotionMode)randomizer.Next(0, motionModeCount),
                Orientation = (SweptTransitionOrientation)randomizer.Next(0, orientationCount),
                InOutKind = (SweptTransitionInOutKind)randomizer.Next(0, inOutKindCount)
            };
        }

        public static BaseFlatSpectrumTransitionContextModel CreateBaseFlatSpectrumTransitionContextModel()
        {
            var randomizer = new System.Random();

            return new BaseFlatSpectrumTransitionContextModel
            {
                UseNeutralFlatSpectrumItems = randomizer.Next(0, 2) == 1,
                UseOpaqueFlatSpectrumItems = randomizer.Next(0, 2) == 1
            };
        }

        public static FlatDualSpectrumHandFanCurtainTransitionContextModel CreateFlatDualSpectrumHandFanCurtainTransitionContextModel()
        {
            var randomizer = new System.Random();

            var modeCount = System.Enum.GetNames(typeof(DualSpectrumHandFanCurtainMode)).Length;

            return new FlatDualSpectrumHandFanCurtainTransitionContextModel
            {
                UseNeutralFlatSpectrumItems = randomizer.Next(0, 2) == 1,
                UseOpaqueFlatSpectrumItems = randomizer.Next(0, 2) == 1,
                Mode = (DualSpectrumHandFanCurtainMode)randomizer.Next(0, modeCount)
            };
        }

        public static FlatSpectrumInverseGothTransitionContextModel CreateFlatSpectrumInverseGothTransitionContextModel()
        {
            var randomizer = new System.Random();

            var easingTypeCount = System.Enum.GetNames(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new FlatSpectrumInverseGothTransitionContextModel
            {
                UseNeutralFlatSpectrumItems = randomizer.Next(0, 2) == 1,
                UseOpaqueFlatSpectrumItems = randomizer.Next(0, 2) == 1,
                HorizontalTransitionOrientation = (Common.Transitioning.Presentation.Enumerations.HorizontalTransitionOrientation)randomizer.Next(1, 3),
                VerticalTransitionOrientation = (Common.Transitioning.Presentation.Enumerations.VerticalTransitionOrientation)randomizer.Next(0, 3),
                HorizontalTransitionEasingType = (SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount),
                VerticalTransitionEasingType = (SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }
    }
}
