namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard
{
    public class HeroLocalNowDateTimePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Enumerations.HeroNowDateTimeStyle Style { get; set; }

        public bool IsDateTimeFramed { get; set; }

        public Templating.Models.Context.BackgroundContextModel Background { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }

        public string TextFontFamily { get; set; }

        public System.Globalization.CultureInfo Culture { get; set; }
    }
}