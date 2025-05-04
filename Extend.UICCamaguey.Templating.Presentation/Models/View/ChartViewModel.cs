namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class ChartViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private LiveChartsCore.ISeries[] series;

        public LiveChartsCore.ISeries[] Series { get => series; set => SetProperty(ref series, value); }

        public LiveChartsCore.Kernel.Sketches.ICartesianAxis[] XAxes { get; set; }

        public LiveChartsCore.Kernel.Sketches.ICartesianAxis[] YAxes { get; set; }
    }
}