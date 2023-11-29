using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class FramePriorityChangePageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public FrameViewModel[] Frames { get; set; }

        public FrameViewModel Target { get; set; }
    }
}
