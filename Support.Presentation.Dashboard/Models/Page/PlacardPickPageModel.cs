using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class PlacardPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel> items;
        private bool hasMoreItems;

        public System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            foreach (var item in Items)
            {
                item.Dispose();
            }

            Items.Clear();

            Items = null;
        }
    }
}