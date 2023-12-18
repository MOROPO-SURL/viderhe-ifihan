namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid3st_2x1PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private bool isOneOfTwoTargetPlacardsScalable;

        public LandscapeGrid3st_2x1PlacardConfigurationPageModel()
        {
            OneOfTwoTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            TwoOfTwoSplitOneOfTwoTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            TwoOfTwoSplitTwoOfTwoTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> OneOfTwoTargetPlacards { get; set; }

        public bool IsOneOfTwoTargetPlacardsScalable { get => isOneOfTwoTargetPlacardsScalable; set => SetProperty(ref isOneOfTwoTargetPlacardsScalable, value); }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TwoOfTwoSplitOneOfTwoTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TwoOfTwoSplitTwoOfTwoTargetPlacards { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            OneOfTwoTargetPlacards.Clear();
            TwoOfTwoSplitOneOfTwoTargetPlacards.Clear();
            TwoOfTwoSplitTwoOfTwoTargetPlacards.Clear();

            OneOfTwoTargetPlacards = null;
            TwoOfTwoSplitOneOfTwoTargetPlacards = null;
            TwoOfTwoSplitTwoOfTwoTargetPlacards = null;
        }
    }
}
