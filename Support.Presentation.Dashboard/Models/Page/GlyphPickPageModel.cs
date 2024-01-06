namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class GlyphPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasPreviousItems;
        private bool hasNextItems;
        private System.Collections.ObjectModel.ObservableCollection<string> items;

        public GlyphPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<string>();
        }

        public System.Collections.ObjectModel.ObservableCollection<string> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasPreviousItems { get => hasPreviousItems; set =>SetProperty(ref hasPreviousItems, value); }

        public bool HasNextItems { get => hasNextItems; set => SetProperty(ref hasNextItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
