namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class EditVideoPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public Support.Presentation.Models.View.VideoViewModel Video { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
