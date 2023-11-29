using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class VideoComplementConfigurationPageModel : FormPageModel
    {
        private VideoViewModel video;
        private VideoComplementPosition position;
        private int delay;

        public VideoComplementConfigurationPageModel()
        {
            position = VideoComplementPosition.BottomRight;

            AvailableVideoComplementPositions = new VideoComplementPosition[]
            {
                VideoComplementPosition.TopLeft,
                VideoComplementPosition.TopRight,
                VideoComplementPosition.BottomLeft,
                VideoComplementPosition.BottomRight
            };
        }

        public VideoViewModel Video { get => video; set => SetProperty(ref video, value); }

        public VideoComplementPosition Position { get => position; set => SetProperty(ref position, value); }

        public int Delay { get => delay; set => SetProperty(ref delay, value); }

        public VideoComplementPosition[] AvailableVideoComplementPositions { get; private set; }
    }
}
