namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeAnonimusHeroPlacardConfigurationPageModel : Contract.AbstractMuseographyPlacardConfigurationPageModel
    {
        private string caption;
        private int captionFontSize;
        private Support.Presentation.Models.View.ImageViewModel heroImage;
        private Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode backgroundMode;

        public LandscapeAnonimusHeroPlacardConfigurationPageModel()
        {
            CaptionFontSize = 24;

            AvailableAnonimusHeroBackgroundModes = new Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode[]
            {
                Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode.OldPaper,
                Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode.GrayGranite,
                Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode.OrangeGranite
            };
        }

        public string Caption { get => caption; set => SetProperty(ref caption, value); }

        public int CaptionFontSize { get => captionFontSize; set => SetProperty(ref captionFontSize, value); }

        public Support.Presentation.Models.View.ImageViewModel HeroImage { get => heroImage; set => SetProperty(ref heroImage, value); }

        public Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode BackgroundMode { get => backgroundMode; set => SetProperty(ref backgroundMode, value); }

        public Templating.Presentation.Enumerations.AnonimusHeroBackgroundMode[] AvailableAnonimusHeroBackgroundModes { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            HeroImage = null;
        }
    }
}
