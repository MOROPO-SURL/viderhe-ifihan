using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class GovDecisorPrototype1PlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        private ChartViewModel globalObjectivesStatusChart;
        private ChartViewModel monthlyObjectivesProgressChart;
        private int proyectionCount;
        private int actionCount;
        private int indicatorCount;

        public ChartViewModel GlobalObjectivesStatusChart { get => globalObjectivesStatusChart; set => SetProperty(ref globalObjectivesStatusChart, value); }

        public ChartViewModel MonthlyObjectivesProgressChart { get => monthlyObjectivesProgressChart; set => SetProperty(ref monthlyObjectivesProgressChart, value); }

        public int ProyectionCount { get => proyectionCount; set => SetProperty(ref proyectionCount, value); }

        public int ActionCount { get => actionCount; set => SetProperty(ref actionCount, value); }

        public int IndicatorCount { get => indicatorCount; set => SetProperty(ref indicatorCount, value); }

        public ObservableCollection<ObjectiveOverviewViewModel> ObjectiveOverviews { get; private set; } = new ObservableCollection<ObjectiveOverviewViewModel>();

        public GovDecisorPrototype1PlacardViewModel()
        {
            GlobalObjectivesStatusChart = new ChartViewModel();
            MonthlyObjectivesProgressChart = new ChartViewModel
            {
                XAxes = new LiveChartsCore.Kernel.Sketches.ICartesianAxis[] {
                    new LiveChartsCore.SkiaSharpView.Axis
                    {
                        LabelsRotation = -15,
                        Labels = new string[] { "Objetivo 1", "Objetivo 2", "Objetivo 3", "Objetivo 4", "Objetivo 5", "Objetivo 6", "Objetivo 7", "Objetivo 8", "Objetivo 9", "Objetivo 10" },
                        ForceStepToMin = true,
                        MinStep = 1
                    }
                },
                YAxes = new LiveChartsCore.Kernel.Sketches.ICartesianAxis[] {
                    new LiveChartsCore.SkiaSharpView.Axis
                    {
                        Labels = new string[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" },
                        ForceStepToMin = true,
                        MinStep = 1
                    }
                }
            };
        }
    }
}
