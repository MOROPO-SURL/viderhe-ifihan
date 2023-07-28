using SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.View;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageImagesPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<ImageViewModel>> items;

        public ManageImagesPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<ImageViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<ImageViewModel>> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
