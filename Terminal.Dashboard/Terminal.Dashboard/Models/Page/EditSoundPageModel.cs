using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class EditSoundPageModel : FormPageModel
    {
        public SoundViewModel Sound { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Sound = null;
        }
    }
}
