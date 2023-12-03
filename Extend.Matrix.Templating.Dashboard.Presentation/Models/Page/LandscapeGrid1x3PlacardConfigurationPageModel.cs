namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid1x3PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        public LandscapeGrid1x3PlacardConfigurationPageModel()
        {
            OneOfThreeTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            TwoOfThreeTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            ThreeOfThreeTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> OneOfThreeTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TwoOfThreeTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> ThreeOfThreeTargetPlacards { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            OneOfThreeTargetPlacards.Clear();
            TwoOfThreeTargetPlacards.Clear();
            ThreeOfThreeTargetPlacards.Clear();

            OneOfThreeTargetPlacards = null;
            TwoOfThreeTargetPlacards = null;
            ThreeOfThreeTargetPlacards = null;
        }
    }
}
