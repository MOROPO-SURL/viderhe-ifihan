using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;

[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers.StaticResourceProvider))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Providers
{
    public sealed class StaticResourceProvider : IStaticResourceProviderFacade
    {
        public double TinyBodyTextFontSize => 6;

        public double SmallBodyTextFontSize => 8;

        public double NormalBodyTextFontSize => 10;

        public double MiddleBodyTextFontSize => 12;

        public double LargeBodyTextFontSize => 14;

        public double TinyHeaderTextFontSize => 15;

        public double SmallHeaderTextFontSize => 17;

        public double NormalHeaderTextFontSize => 19;

        public double MiddleHeaderTextFontSize => 21;

        public double LargeHeaderTextFontSize => 23;

        public double TinyTitleTextFontSize => 24;

        public double SmallTitleTextFontSize => 26;

        public double NormalTitleTextFontSize => 32;

        public double MiddleTitleTextFontSize => 36;

        public double LargeTitleTextFontSize => 44;

        public double TinyHeroTextFontSize => 46;

        public double SmallHeroTextFontSize => 52;

        public double NormalHeroTextFontSize => 60;

        public double MiddleHeroTextFontSize => 70;

        public double LargeHeroTextFontSize => 92;
    }
}