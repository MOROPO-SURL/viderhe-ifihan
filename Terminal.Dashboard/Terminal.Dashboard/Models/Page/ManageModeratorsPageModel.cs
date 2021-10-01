namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageModeratorsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageModeratorsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.ModeratorViewModel> ();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.ModeratorViewModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
