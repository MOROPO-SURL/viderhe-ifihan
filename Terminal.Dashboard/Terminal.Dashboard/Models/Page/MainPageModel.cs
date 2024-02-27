using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class MainPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public MainPageModel()
        {
            Actions = new System.Collections.ObjectModel.ObservableCollection<ActionViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<ActionViewModel> Actions { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Actions.Clear();

            Actions = null;
        }
    }
}
