namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class HeroLocalNowDateTimePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Enumerations.HeroNowDateTimeStyle style;
        private bool isDateTimeFramed;
        private Templating.Models.Context.BackgroundContextModel background;
        private Xamarin.Forms.Color textColor;
        private string culture;

        public HeroLocalNowDateTimePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 5;
            AvailableStyles = new Enumerations.HeroNowDateTimeStyle[] { Enumerations.HeroNowDateTimeStyle.DateTimeWithSeparatorRectangle };
            AvailableCultures = new string[] { "es-ES" };
        }

        public Enumerations.HeroNowDateTimeStyle Style { get => style; set => style = value; }

        public Enumerations.HeroNowDateTimeStyle[] AvailableStyles { get; private set; }

        public bool IsDateTimeFramed { get => isDateTimeFramed; set => isDateTimeFramed = value; }

        public Templating.Models.Context.BackgroundContextModel Background { get => background; set => background = value; }

        public Xamarin.Forms.Color TextColor { get => textColor; set => textColor = value; }

        public string Culture { get => culture; set => culture = value; }

        public string[] AvailableCultures { get; private set; }
    }
}
