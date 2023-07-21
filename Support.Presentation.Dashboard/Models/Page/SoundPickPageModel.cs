namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class SoundPickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public SoundPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.SoundViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.SoundViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
