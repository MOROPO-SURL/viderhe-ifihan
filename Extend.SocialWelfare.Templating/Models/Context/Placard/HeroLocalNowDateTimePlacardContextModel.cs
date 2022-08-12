namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Models.Context.Placard
{
    public class HeroLocalNowDateTimePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Enumerations.HeroNowDateTimeStyle Style { get; set; }

        public bool IsDateTimeFramed { get; set; }

        public string TextColor { get; set; }

        public string TextFontFamily { get; set; }

        public BackgroundContextModel Background { get; set; }

        public string Culture { get; set; }
    }
}
