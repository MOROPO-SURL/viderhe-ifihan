namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeAnonimusHeroPlacardContextModel : Contract.AbstractMuseographyPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel HeroImage { get; set; }

        public Enumerations.AnonimusHeroBackgroundMode BackgroundMode { get; set; }
    }
}
