using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class AddImagePageModel : FormPageModel
    {
        private string about;

        public AddImagePageModel()
        {
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public Xamarin.Forms.ImageSource ImageSource { get; set; }

        public string Format { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ImageSource = null;
        }
    }
}
