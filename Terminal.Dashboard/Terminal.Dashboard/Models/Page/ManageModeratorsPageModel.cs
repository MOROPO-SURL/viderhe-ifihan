using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManageModeratorsPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageModeratorsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<ModeratorViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<ModeratorViewModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
