namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class ManageVideosPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageVideosPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.VideoViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.VideoViewModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
