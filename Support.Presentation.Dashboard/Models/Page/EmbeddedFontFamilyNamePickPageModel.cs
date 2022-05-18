namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class EmbeddedFontFamilyNamePickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public EmbeddedFontFamilyNamePickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<string>();
        }

        public System.Collections.ObjectModel.ObservableCollection<string> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
