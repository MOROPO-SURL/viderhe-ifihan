using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class ImagePickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<ImageViewModel>> items;

        public ImagePickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<ImageViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<ImageViewModel>> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
