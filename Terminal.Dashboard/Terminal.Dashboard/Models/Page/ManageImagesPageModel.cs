namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class ManageImagesPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public ManageImagesPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.ImageViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.ImageViewModel> Items { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
