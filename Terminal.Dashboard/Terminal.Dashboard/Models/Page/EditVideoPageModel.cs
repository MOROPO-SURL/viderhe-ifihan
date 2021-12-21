namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditVideoPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        public Support.Presentation.Models.View.VideoViewModel Video { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
