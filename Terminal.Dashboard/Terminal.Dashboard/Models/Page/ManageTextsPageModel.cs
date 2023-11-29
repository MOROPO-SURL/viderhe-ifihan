using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageTextsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public ManageTextsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<TextViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<TextViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
