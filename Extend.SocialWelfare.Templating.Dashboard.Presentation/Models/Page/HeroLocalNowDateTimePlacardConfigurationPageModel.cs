namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Models.Page
{
    public class HeroLocalNowDateTimePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private const string DEFAULT_CULTURE = "es-ES";

        private Enumerations.HeroNowDateTimeStyle style;
        private bool isDateTimeFramed;
        private Templating.Models.Context.BackgroundContextModel background;
        private Xamarin.Forms.Color textColor;
        private string culture;

        public HeroLocalNowDateTimePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 5;
            Style = Enumerations.HeroNowDateTimeStyle.DateTimeWithSeparatorRectangle;
            AvailableStyles = new Enumerations.HeroNowDateTimeStyle[] { Enumerations.HeroNowDateTimeStyle.DateTimeWithSeparatorRectangle };
            Culture = DEFAULT_CULTURE;
            AvailableCultures = new string[] { DEFAULT_CULTURE, "en-EN" };
        }

        public Enumerations.HeroNowDateTimeStyle Style { get => style; set => SetProperty(ref style, value); }

        public Enumerations.HeroNowDateTimeStyle[] AvailableStyles { get; private set; }

        public bool IsDateTimeFramed { get => isDateTimeFramed; set => SetProperty(ref isDateTimeFramed, value); }

        public Templating.Models.Context.BackgroundContextModel Background { get => background; set =>  SetProperty(ref background, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set =>  SetProperty(ref textColor, value); }

        public string Culture { get => culture; set => SetProperty(ref culture, value); }

        public string[] AvailableCultures { get; private set; }
    }
}
