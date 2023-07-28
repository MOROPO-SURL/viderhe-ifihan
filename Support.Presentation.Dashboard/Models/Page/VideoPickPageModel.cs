namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class VideoPickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<Presentation.Models.View.VideoViewModel>> items;

        public VideoPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<Presentation.Models.View.VideoViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.OverviewViewModel<Presentation.Models.View.VideoViewModel>> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
