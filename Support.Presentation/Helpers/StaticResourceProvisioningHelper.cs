namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Helpers
{
    public static class StaticResourceProvisioningHelper
    {
        private static readonly Providers.Facade.IStaticResourceProviderFacade providers = Xamarin.Forms.DependencyService.Get<Providers.Facade.IStaticResourceProviderFacade>();

        public static double TinyBodyTextFontSize => providers.TinyBodyTextFontSize;
        public static double SmallBodyTextFontSize => providers.SmallBodyTextFontSize;
        public static double NormalBodyTextFontSize => providers.NormalBodyTextFontSize;
        public static double MiddleBodyTextFontSize => providers.MiddleBodyTextFontSize;
        public static double LargeBodyTextFontSize => providers.LargeBodyTextFontSize;

        public static double TinyHeaderTextFontSize => providers.TinyHeaderTextFontSize;
        public static double SmallHeaderTextFontSize => providers.SmallHeaderTextFontSize;
        public static double NormalHeaderTextFontSize => providers.NormalHeaderTextFontSize;
        public static double MiddleHeaderTextFontSize => providers.MiddleHeaderTextFontSize;
        public static double LargeHeaderTextFontSize => providers.LargeHeaderTextFontSize;

        public static double TinyTitleTextFontSize => providers.TinyTitleTextFontSize;
        public static double SmallTitleTextFontSize => providers.SmallTitleTextFontSize;
        public static double NormalTitleTextFontSize => providers.NormalTitleTextFontSize;
        public static double MiddleTitleTextFontSize => providers.MiddleTitleTextFontSize;
        public static double LargeTitleTextFontSize => providers.LargeTitleTextFontSize;

        public static double TinyHeroTextFontSize => providers.TinyHeroTextFontSize;
        public static double SmallHeroTextFontSize => providers.SmallHeroTextFontSize;
        public static double NormalHeroTextFontSize => providers.NormalHeroTextFontSize;
        public static double MiddleHeroTextFontSize => providers.MiddleHeroTextFontSize;
        public static double LargeHeroTextFontSize => providers.LargeHeroTextFontSize;
    }
}
