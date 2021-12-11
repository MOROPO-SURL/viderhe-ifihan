namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditImagePageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        public Support.Presentation.Models.View.ImageViewModel Image { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;
        }
    }
}
