namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageSoundsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private View.SoundViewModel target;

        public ManageSoundsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.SoundViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.SoundViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        public View.SoundViewModel Target 
        { 
            get => target; 
            set => SetProperty(ref target, value); 
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Target = null;

            Items.Clear();

            Items = null;
        }
    }
}
