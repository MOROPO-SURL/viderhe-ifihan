using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class VideoPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<VideoViewModel>> items;

        public VideoPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<VideoViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<VideoViewModel>> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
