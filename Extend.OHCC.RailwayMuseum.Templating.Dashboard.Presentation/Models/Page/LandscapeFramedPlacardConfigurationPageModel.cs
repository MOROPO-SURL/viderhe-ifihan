using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeFramedPlacardConfigurationPageModel : Contract.AbstractMuseographyPlacardConfigurationPageModel
    {
        private FrameStyle frameStyle;
        private BackgroundMode backgroundMode;

        public LandscapeFramedPlacardConfigurationPageModel()
        {
            AvailableFrameStyles = new FrameStyle[]
            {
                FrameStyle.Fancy,
                FrameStyle.Tally
            };

            AvailableBackgroundModes = new BackgroundMode[]
            {
                BackgroundMode.SolidPrimary,
                BackgroundMode.SolidSecoundary,
                //BackgroundMode.SolidLight,
                //BackgroundMode.SolidDark,
                //BackgroundMode.GradientLinearV1,
                //BackgroundMode.GradientLinearV2,
                //BackgroundMode.TextureWallPrimaryLigth,
                //BackgroundMode.TextureWallPrimaryDark,
                //BackgroundMode.TextureWallSecoundaryLigth,
                //BackgroundMode.TextureWallSecoundaryDark,
                //BackgroundMode.TextureOldPaper,
                //BackgroundMode.TextureGraniteOrange,
                //BackgroundMode.TextureGraniteGray
            };
        }

        public FrameStyle FrameStyle { get => frameStyle; set => SetProperty(ref frameStyle, value); }

        public FrameStyle[] AvailableFrameStyles { get; private set; }

        public BackgroundMode BackgroundMode { get => backgroundMode; set => SetProperty(ref backgroundMode, value); }

        public BackgroundMode[] AvailableBackgroundModes { get; private set; }
    }
}
