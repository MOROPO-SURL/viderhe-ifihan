using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class CreateSimpleVideoPlacardPageModel : AbstractLabeledPlacardConfigurationPageModel
    {
        public VideoViewModel Video { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
