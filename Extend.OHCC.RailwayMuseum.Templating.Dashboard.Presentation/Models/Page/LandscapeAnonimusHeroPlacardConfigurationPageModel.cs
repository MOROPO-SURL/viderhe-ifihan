using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeAnonimusHeroPlacardConfigurationPageModel : Contract.AbstractMuseographyPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel heroImage;
        private AnonimusHeroBackgroundMode backgroundMode;

        public LandscapeAnonimusHeroPlacardConfigurationPageModel()
        {
            AvailableAnonimusHeroBackgroundModes = new AnonimusHeroBackgroundMode[]
            {
                AnonimusHeroBackgroundMode.OldPaper,
                AnonimusHeroBackgroundMode.GrayGranite,
                AnonimusHeroBackgroundMode.OrangeGranite
            };
        }

        public Support.Presentation.Models.View.ImageViewModel HeroImage { get => heroImage; set => SetProperty(ref heroImage, value); }

        public AnonimusHeroBackgroundMode BackgroundMode { get => backgroundMode; set => SetProperty(ref backgroundMode, value); }

        public AnonimusHeroBackgroundMode[] AvailableAnonimusHeroBackgroundModes { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            HeroImage = null;
        }
    }
}
