namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class VideoComplementConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private Support.Presentation.Models.View.VideoViewModel video;
        private Extend.Common.Templating.Enumerations.VideoComplementPosition position;
        private int delay;

        public VideoComplementConfigurationPageModel()
        {
            position = Extend.Common.Templating.Enumerations.VideoComplementPosition.BottomRight;

            AvailableVideoComplementPositions = new Extend.Common.Templating.Enumerations.VideoComplementPosition[]
            {
                Extend.Common.Templating.Enumerations.VideoComplementPosition.TopLeft,
                Extend.Common.Templating.Enumerations.VideoComplementPosition.TopRight,
                Extend.Common.Templating.Enumerations.VideoComplementPosition.BottomLeft,
                Extend.Common.Templating.Enumerations.VideoComplementPosition.BottomRight
            };
        }

        public Support.Presentation.Models.View.VideoViewModel Video { get => video; set => SetProperty(ref video, value); }

        public Extend.Common.Templating.Enumerations.VideoComplementPosition Position { get => position; set => SetProperty(ref position, value); }

        public int Delay { get => delay; set => SetProperty(ref delay, value); }

        public Extend.Common.Templating.Enumerations.VideoComplementPosition[] AvailableVideoComplementPositions { get; private set; }
    }
}
