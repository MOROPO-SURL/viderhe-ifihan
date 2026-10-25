using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManageGradientTagsPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageGradientTagsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
