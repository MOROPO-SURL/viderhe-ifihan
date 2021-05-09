namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionContextModelFactory
    {
        public static Models.Context.CarouselTransitionContextModel CreateCarouselTransitionContextModel()
        {
            var randomizer = new System.Random();

            var standardTransitionDirectionCount = System.Enum.GetNames(typeof(Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)).Length;
            var easingTypeCount = System.Enum.GetNames(typeof(XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new Models.Context.CarouselTransitionContextModel
            {
                Direction = (Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)randomizer.Next(0, standardTransitionDirectionCount),
                MotionEasingType = (XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static Models.Context.ArriveTransitionContextModel CreateArriveTransitionContextModel()
        {
            var randomizer = new System.Random();

            var standardTransitionDirectionCount = System.Enum.GetNames(typeof(Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)).Length;
            var easingTypeCount = System.Enum.GetNames(typeof(XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new Models.Context.ArriveTransitionContextModel
            {
                Direction = (Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)randomizer.Next(0, standardTransitionDirectionCount),
                MotionEasingType = (XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static Models.Context.ZoomInTransitionContextModel CreateZoomInTransitionContextModel()
        {
            var randomizer = new System.Random();

            var easingTypeCount = System.Enum.GetNames(typeof(XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new Models.Context.ZoomInTransitionContextModel
            {
                MotionEasingType = (XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }

        public static Models.Context.FadeInTransitionContextModel CreateFadeInTransitionContextModel()
        {
            var randomizer = new System.Random();

            var verticalTransitionOrientationCount = System.Enum.GetNames(typeof(Common.Transitioning.Presentation.Enumerations.VerticalTransitionOrientation)).Length;

            return new Models.Context.FadeInTransitionContextModel
            {
                MotionDirection = (Common.Transitioning.Presentation.Enumerations.VerticalTransitionOrientation)randomizer.Next(0, verticalTransitionOrientationCount)
            };
        }
    }
}
