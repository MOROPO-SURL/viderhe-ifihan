namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageExtensionsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageExtensionsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.ExtensionViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.ExtensionViewModel> Items { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
