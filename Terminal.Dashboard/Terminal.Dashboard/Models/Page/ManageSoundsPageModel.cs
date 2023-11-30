using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManageSoundsPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private SoundViewModel target;

        public ManageSoundsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<SoundViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<SoundViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        public SoundViewModel Target
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
