using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeAnonimusHeroPlacardContextModel : Contract.AbstractMuseographyPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel HeroImage { get; set; }

        public AnonimusHeroBackgroundMode BackgroundMode { get; set; }
    }
}
