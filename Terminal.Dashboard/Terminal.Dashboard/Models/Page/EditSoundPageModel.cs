using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditSoundPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        public SoundViewModel Sound { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Sound = null;
        }
    }
}
