namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid2x1PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private bool isOneOfTwoTargetPlacardsScalable;
        private bool isTwoOfTwoTargetPlacardsScalable;

        public LandscapeGrid2x1PlacardConfigurationPageModel()
        {
            OneOfTwoTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            TwoOfTwoTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> OneOfTwoTargetPlacards { get; set; }

        public bool IsOneOfTwoTargetPlacardsScalable { get => isOneOfTwoTargetPlacardsScalable; set => SetProperty(ref isOneOfTwoTargetPlacardsScalable, value); }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TwoOfTwoTargetPlacards { get; set; }

        public bool IsTwoOfTwoTargetPlacardsScalable { get => isTwoOfTwoTargetPlacardsScalable; set => SetProperty(ref isTwoOfTwoTargetPlacardsScalable, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            OneOfTwoTargetPlacards.Clear();
            TwoOfTwoTargetPlacards.Clear();

            OneOfTwoTargetPlacards = null;
            TwoOfTwoTargetPlacards = null;
        }
    }
}
