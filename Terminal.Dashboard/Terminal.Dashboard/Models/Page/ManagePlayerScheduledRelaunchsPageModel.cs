using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManagePlayerScheduledRelaunchsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManagePlayerScheduledRelaunchsPageModel(View.PlayerViewModel player)
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<ScheduledRelaunchDisplayModel>();

            Player = player;
        }

        public View.PlayerViewModel Player { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<ScheduledRelaunchDisplayModel> Items { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
