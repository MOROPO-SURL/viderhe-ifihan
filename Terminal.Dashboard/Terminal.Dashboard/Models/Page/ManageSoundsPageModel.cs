namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageSoundsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private Support.Presentation.Dashboard.Models.View.SoundViewModel target;

        public ManageSoundsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.SoundViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.SoundViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        public Support.Presentation.Dashboard.Models.View.SoundViewModel Target 
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
