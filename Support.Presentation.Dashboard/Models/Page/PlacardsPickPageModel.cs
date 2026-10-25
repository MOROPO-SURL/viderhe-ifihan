using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class PlacardsPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreImages;

        public PlacardsPickPageModel()
        {
            SelectablePlacards = new System.Collections.ObjectModel.ObservableCollection<SelectableModelViewModel<PlacardOverviewViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<SelectableModelViewModel<PlacardOverviewViewModel>> SelectablePlacards { get; set; }

        public bool HasMoreImages { get => hasMoreImages; set => SetProperty(ref hasMoreImages, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            SelectablePlacards.Clear();

            SelectablePlacards = null;
        }
    }
}
