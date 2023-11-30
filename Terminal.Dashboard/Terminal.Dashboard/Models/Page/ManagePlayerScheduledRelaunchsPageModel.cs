using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManagePlayerScheduledRelaunchsPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManagePlayerScheduledRelaunchsPageModel(PlayerViewModel player)
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<ScheduledRelaunchDisplayModel>();

            Player = player;
        }

        public PlayerViewModel Player { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<ScheduledRelaunchDisplayModel> Items { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
