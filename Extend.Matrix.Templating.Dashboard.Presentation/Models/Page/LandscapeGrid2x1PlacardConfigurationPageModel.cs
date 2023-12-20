namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid2x1PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private bool isTopCellPlacardsScalable;
        private bool isTopCellScreenplayTimeRector;
        private bool isBottomCellPlacardsScalable;
        private bool isBottomCellScreenplayTimeRector;

        public LandscapeGrid2x1PlacardConfigurationPageModel()
        {
            TopCellPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            BottomCellPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get => isTopCellPlacardsScalable; set => SetProperty(ref isTopCellPlacardsScalable, value); }

        public bool IsTopCellScreenplayTimeRector { get => isTopCellScreenplayTimeRector; set => SetProperty(ref isTopCellScreenplayTimeRector, value, IsTopCellScreenplayTimeRector_ChangeCallback); }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> BottomCellPlacards { get; set; }

        public bool IsBottomCellPlacardsScalable { get => isBottomCellPlacardsScalable; set => SetProperty(ref isBottomCellPlacardsScalable, value); }

        public bool IsBottomCellScreenplayTimeRector { get => isBottomCellScreenplayTimeRector; set => SetProperty(ref isBottomCellScreenplayTimeRector, value, IsBottomCellScreenplayTimeRector_ChangeCallback); }

        private void IsTopCellScreenplayTimeRector_ChangeCallback()
        {
            if (isTopCellScreenplayTimeRector)
            {
                IsBottomCellScreenplayTimeRector = false;
            }
        }

        private void IsBottomCellScreenplayTimeRector_ChangeCallback()
        {
            if (isBottomCellScreenplayTimeRector)
            {
                IsTopCellScreenplayTimeRector = false;
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            TopCellPlacards.Clear();
            BottomCellPlacards.Clear();

            TopCellPlacards = null;
            BottomCellPlacards = null;
        }
    }
}
