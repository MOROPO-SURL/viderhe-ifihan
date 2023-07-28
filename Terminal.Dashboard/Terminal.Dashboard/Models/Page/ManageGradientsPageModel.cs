using SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageGradientsPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreItems;
        private System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<GradientViewModel>> items;

        public ManageGradientsPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<GradientViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<GradientViewModel>> Items { get => items; set => SetProperty(ref items, value); }

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;
        }
    }
}
