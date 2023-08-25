namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractManagementPageModel<T> : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public AbstractManagementPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<T>();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
