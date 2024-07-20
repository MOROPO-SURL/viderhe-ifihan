namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class AmbientalDashboardPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        //private AmbientalReadingDisplayModel lastReading;
        private Microcharts.LineChart chart;

        public AmbientalDashboardPlacardViewModel()
        {
            chart = new Microcharts.LineChart
            {
                PointMode = Microcharts.PointMode.Circle,
                AnimationDuration = System.TimeSpan.FromMilliseconds(150),
                LineMode = Microcharts.LineMode.Straight
            };
        }

        //public AmbientalReadingDisplayModel LastReading { get => lastReading; set => SetProperty(ref lastReading, value); }

        public Microcharts.LineChart Chart { get => chart; set => SetProperty(ref chart, value); }

        public Enumerations.AmbientalVariable AmbientalVariable { get; set; }
    }
}
