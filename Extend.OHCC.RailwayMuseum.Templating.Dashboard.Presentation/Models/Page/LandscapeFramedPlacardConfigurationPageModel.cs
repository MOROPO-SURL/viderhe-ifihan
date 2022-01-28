namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeFramedPlacardConfigurationPageModel : Contract.AbstractMuseographyPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.FrameStyle frameStyle;
        private Templating.Presentation.Enumerations.BackgroundMode backgroundMode;

        public LandscapeFramedPlacardConfigurationPageModel()
        {
            AvailableFrameStyles = new Templating.Presentation.Enumerations.FrameStyle[]
            {
                Templating.Presentation.Enumerations.FrameStyle.Fancy,
                Templating.Presentation.Enumerations.FrameStyle.Tally
            };

            AvailableBackgroundModes = new Templating.Presentation.Enumerations.BackgroundMode[]
            {
                Templating.Presentation.Enumerations.BackgroundMode.SolidPrimary,
                Templating.Presentation.Enumerations.BackgroundMode.SolidSecoundary,
                //Templating.Presentation.Enumerations.BackgroundMode.SolidLight,
                //Templating.Presentation.Enumerations.BackgroundMode.SolidDark,
                //Templating.Presentation.Enumerations.BackgroundMode.GradientLinearV1,
                //Templating.Presentation.Enumerations.BackgroundMode.GradientLinearV2,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureWallPrimaryLigth,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureWallPrimaryDark,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureWallSecoundaryLigth,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureWallSecoundaryDark,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureOldPaper,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureGraniteOrange,
                //Templating.Presentation.Enumerations.BackgroundMode.TextureGraniteGray
            };
        }

        public Templating.Presentation.Enumerations.FrameStyle FrameStyle { get => frameStyle; set => SetProperty(ref frameStyle, value); }

        public Templating.Presentation.Enumerations.FrameStyle[] AvailableFrameStyles { get; private set; }

        public Templating.Presentation.Enumerations.BackgroundMode BackgroundMode { get => backgroundMode; set => SetProperty(ref backgroundMode, value); }

        public Templating.Presentation.Enumerations.BackgroundMode[] AvailableBackgroundModes { get; private set; }
    }
}
