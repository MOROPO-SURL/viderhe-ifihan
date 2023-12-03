using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class TextPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public TextPickPageModel()
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
