namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditSoundPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        public Support.Presentation.Dashboard.Models.View.SoundViewModel Sound { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Sound = null;
        }
    }
}
