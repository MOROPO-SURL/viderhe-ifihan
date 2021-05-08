namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Transitioning.Presentation.Factories
{
    public static class RandomTransitionContextModelFactory
    {
        public static Models.Context.SimpleCarouselTransitionContextModel CreateSimpleCarouselTransitionContextModel()
        {
            var randomizer = new System.Random();

            var standardTransitionDirectionCount = System.Enum.GetNames(typeof(Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)).Length;
            var easingTypeCount = System.Enum.GetNames(typeof(XFToolKit.Presentation.Transform.Enumerations.EasingType)).Length;

            return new Models.Context.SimpleCarouselTransitionContextModel
            {
                Direction = (Common.Transitioning.Presentation.Enumerations.StandardTransitionDirection)randomizer.Next(1, standardTransitionDirectionCount),
                MotionEasingType = (XFToolKit.Presentation.Transform.Enumerations.EasingType)randomizer.Next(0, easingTypeCount)
            };
        }
    }
}
