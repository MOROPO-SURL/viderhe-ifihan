using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class FramePriorityChangePageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public FrameViewModel[] Frames { get; set; }

        public FrameViewModel Target { get; set; }
    }
}
