using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class SoundPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public SoundPickPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<SoundViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<SoundViewModel> Items { get; set; }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
