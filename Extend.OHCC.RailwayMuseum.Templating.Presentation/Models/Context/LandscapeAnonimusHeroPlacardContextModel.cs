namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class LandscapeAnonimusHeroPlacardContextModel : Contract.AbstractMuseographyPlacardContextModel
    {
        public string Caption { get; set; }

        public int CaptionFontSize { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel HeroImage { get; set; }

        public Enumerations.AnonimusHeroBackgroundMode BackgroundMode { get; set; }
    }
}
