using MOROPO.VIDERHE.Extend.Common.Transitioning.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionContextModelFactory
    {
        public static CarouselTransitionContextModel CreateCarouselTransitionContextModel()
        {
            var randomizer = new System.Random();

            var standardTransitionDirectionCount = System.Enum.GetNames(typeof(StandardTransitionDirection)).Length;
            var easingTypeCount = System.Enum.GetNames(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new CarouselTransitionContextModel
            {
                Direction = (StandardTransitionDirection)randomizer.Next(0, standardTransitionDirectionCount),
                MotionEasingType = (SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static ArriveTransitionContextModel CreateArriveTransitionContextModel()
        {
            var randomizer = new System.Random();

            var standardTransitionDirectionCount = System.Enum.GetNames(typeof(StandardTransitionDirection)).Length;
            var easingTypeCount = System.Enum.GetNames(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new ArriveTransitionContextModel
            {
                Direction = (StandardTransitionDirection)randomizer.Next(0, standardTransitionDirectionCount),
                MotionEasingType = (SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static ZoomInTransitionContextModel CreateZoomInTransitionContextModel()
        {
            var randomizer = new System.Random();

            var easingTypeCount = System.Enum.GetNames(typeof(SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new ZoomInTransitionContextModel
            {
                MotionEasingType = (SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static FadeInTransitionContextModel CreateFadeInTransitionContextModel()
        {
            var randomizer = new System.Random();

            var verticalTransitionOrientationCount = System.Enum.GetNames(typeof(VerticalTransitionOrientation)).Length;

            return new FadeInTransitionContextModel
            {
                MotionDirection = (VerticalTransitionOrientation)randomizer.Next(0, verticalTransitionOrientationCount)
            };
        }
    }
}
