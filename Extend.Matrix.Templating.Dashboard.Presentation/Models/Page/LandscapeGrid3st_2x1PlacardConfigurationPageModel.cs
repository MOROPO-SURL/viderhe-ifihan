namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid3st_2x1PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private bool isTopCellPlacardsScalable;
        private bool isTopCellScreenplayTimeRector;
        private bool isBottomLeftCellScreenplayTimeRector;
        private bool isBottomRightCellScreenplayTimeRector;

        public LandscapeGrid3st_2x1PlacardConfigurationPageModel()
        {
            TopCellPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            BottomLeftCellPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            BottomRightCellPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TopCellPlacards { get; set; }

        public bool IsTopCellPlacardsScalable { get => isTopCellPlacardsScalable; set => SetProperty(ref isTopCellPlacardsScalable, value); }

        public bool IsTopCellScreenplayTimeRector { get => isTopCellScreenplayTimeRector; set => SetProperty(ref isTopCellScreenplayTimeRector, value, IsTopCellScreenplayTimeRector_ChangeCallback); }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> BottomLeftCellPlacards { get; set; }

        public bool IsBottomLeftCellScreenplayTimeRector { get => isBottomLeftCellScreenplayTimeRector; set => SetProperty(ref isBottomLeftCellScreenplayTimeRector, value, IsBottomLeftCellScreenplayTimeRector_ChangeCallback); }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> BottomRightCellPlacards { get; set; }

        public bool IsBottomRightCellScreenplayTimeRector { get => isBottomRightCellScreenplayTimeRector; set => SetProperty(ref isBottomRightCellScreenplayTimeRector, value, IsBottomRighCellScreenplayTimeRector_ChangeCallback); }

        private void IsTopCellScreenplayTimeRector_ChangeCallback()
        {
            if (isTopCellScreenplayTimeRector)
            {
                IsBottomLeftCellScreenplayTimeRector = false;
                IsBottomRightCellScreenplayTimeRector = false;
            }
        }

        private void IsBottomLeftCellScreenplayTimeRector_ChangeCallback()
        {
            if (isBottomLeftCellScreenplayTimeRector)
            {
                IsTopCellScreenplayTimeRector = false;
                IsBottomRightCellScreenplayTimeRector = false;
            }
        }

        private void IsBottomRighCellScreenplayTimeRector_ChangeCallback()
        {
            if (isBottomRightCellScreenplayTimeRector)
            {
                IsTopCellScreenplayTimeRector = false;
                IsBottomLeftCellScreenplayTimeRector = false;
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            TopCellPlacards.Clear();
            BottomLeftCellPlacards.Clear();
            BottomRightCellPlacards.Clear();

            TopCellPlacards = null;
            BottomLeftCellPlacards = null;
            BottomRightCellPlacards = null;
        }
    }
}
