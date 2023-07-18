namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class TextPickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public TextPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.TextViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.TextViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
