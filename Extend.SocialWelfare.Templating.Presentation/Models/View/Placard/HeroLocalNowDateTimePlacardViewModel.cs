using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard
{
    public class HeroLocalNowDateTimePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public HeroNowDateTimeStyle Style { get; set; }

        public bool IsDateTimeFramed { get; set; }

        public BackgroundContextModel Background { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }

        public string TextFontFamily { get; set; }

        public System.Globalization.CultureInfo Culture { get; set; }
    }
}