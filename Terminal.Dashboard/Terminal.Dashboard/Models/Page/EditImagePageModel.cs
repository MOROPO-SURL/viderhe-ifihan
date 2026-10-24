using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class EditImagePageModel : FormPageModel
    {
        public EditImagePageModel()
        {
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public ImageViewModel Image { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;
        }
    }
}
