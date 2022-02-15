namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class FramePriorityChangePageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public Support.Presentation.Models.View.FrameViewModel[] Frames { get; set; }

        public Support.Presentation.Models.View.FrameViewModel Target { get; set; }
    }
}
