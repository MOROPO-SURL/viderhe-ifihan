namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManagePlayerTagsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManagePlayerTagsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
