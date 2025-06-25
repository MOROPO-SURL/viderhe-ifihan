namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class GovDecisorPrototype2PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        private ChartViewModel proyectionsStatusChart;
        private ChartViewModel statusChart;
        private ChartViewModel progressionChart;
        private int proyectionCount;
        private int actionCount;
        private int indicatorCount;
        private string objectiveName;
        private int objectiveIndex;
        private SpecificObjectiveModel[] specificObjectives;

        public ChartViewModel ProyectionsStatusChart { get => proyectionsStatusChart; set => SetProperty(ref proyectionsStatusChart, value); }

        public ChartViewModel StatusChart { get => statusChart; set => SetProperty(ref statusChart, value); }
        
        public ChartViewModel ProgressionChart { get => progressionChart; set => SetProperty(ref progressionChart, value); }
        
        public int ProyectionCount { get => proyectionCount; set => SetProperty(ref proyectionCount, value); }

        public int ActionCount { get => actionCount; set => SetProperty(ref actionCount, value); }

        public int IndicatorCount { get => indicatorCount; set => SetProperty(ref indicatorCount, value); }

        public string ObjectiveName { get => objectiveName; set => SetProperty(ref objectiveName, value); }
        
        public int ObjectiveIndex { get => objectiveIndex; set => SetProperty(ref objectiveIndex, value); }

        public SpecificObjectiveModel[] SpecificObjectives { get => specificObjectives; set => SetProperty(ref specificObjectives, value); }

        public GovDecisorPrototype2PlacardViewModel()
        {
            ProyectionsStatusChart = new ChartViewModel();
            StatusChart = new ChartViewModel();
            ProgressionChart = new ChartViewModel();
        }
    }

    public class SpecificObjectiveModel
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public int ObjectiveIndex { set; get; }

        public ActionModel[] Actions { get; set; }
    }

    public class ActionModel
    {
        public ActionModel()
        {
            ProgressionChart = new ChartViewModel();
        }

        public string Name { get; set; }

        public int Index { get; set; }

        public int SpecificObjectiveIndex { get; set; }

        public int ObjectiveIndex { set; get; }

        public ChartViewModel ProgressionChart { get; set; }

        public Mapsui.Layers.PointFeature[] PointFeatures { get; set; }
    }
}
