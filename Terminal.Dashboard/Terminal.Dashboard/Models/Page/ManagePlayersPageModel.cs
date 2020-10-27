namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class ManagePlayersPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManagePlayersPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.PlayerViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.PlayerViewModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
