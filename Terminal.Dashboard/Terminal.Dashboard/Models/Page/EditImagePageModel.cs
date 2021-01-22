namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditImagePageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public Support.Presentation.Models.View.ImageViewModel Image { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;
        }
    }
}
