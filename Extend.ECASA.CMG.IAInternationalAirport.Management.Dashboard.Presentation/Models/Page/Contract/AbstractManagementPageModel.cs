namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractManagementPageModel<T> : XFToolKit.Mvvm.Models.Page.BasePageModel where T : class
    {
        private T target;
        private System.Collections.ObjectModel.ObservableCollection<T> items;

        public System.Collections.ObjectModel.ObservableCollection<T> Items { get => items; set => SetProperty(ref items, value); }

        public T Target { get => target; set => SetProperty(ref target, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Target = null;

            Items?.Clear();

            Items = null;
        }
    }
}
