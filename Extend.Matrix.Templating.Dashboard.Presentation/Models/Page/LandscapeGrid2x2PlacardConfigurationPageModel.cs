namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeGrid2x2PlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        public LandscapeGrid2x2PlacardConfigurationPageModel()
        {
            OneOfFourTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            TwoOfFourTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            ThreeOfFourTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
            FourOfFourTargetPlacards = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> OneOfFourTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> TwoOfFourTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> ThreeOfFourTargetPlacards { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel> FourOfFourTargetPlacards { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            OneOfFourTargetPlacards.Clear();
            TwoOfFourTargetPlacards.Clear();
            ThreeOfFourTargetPlacards.Clear();
            FourOfFourTargetPlacards.Clear();

            OneOfFourTargetPlacards = null;
            TwoOfFourTargetPlacards = null;
            ThreeOfFourTargetPlacards = null;
            FourOfFourTargetPlacards = null;
        }
    }
}
