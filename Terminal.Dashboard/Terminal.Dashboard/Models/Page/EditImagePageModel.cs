using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class EditImagePageModel : FormPageModel
    {
        public ImageViewModel Image { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;
        }
    }
}
