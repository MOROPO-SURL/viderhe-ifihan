using LiveChartsCore.SkiaSharpView.Extensions;
using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Views
{
    public partial class GovDecisorPrototype1PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public GovDecisorPrototype1PlacardView(GovDecisorPrototype1PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;
        }

        private GovDecisorPrototype1PlacardViewModel ConcreteBindingContext => BindingContext as GovDecisorPrototype1PlacardViewModel;

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var glyphs = new char[] { '\uF05D', '\uF05C', '\uF045', '\uF042', '\uF84E' };

            var gaugeItems = new System.Collections.Generic.List<GaugeItem>();

            var weightedPoints = new System.Collections.Generic.List<LiveChartsCore.Defaults.WeightedPoint>();

            var randomizer = new System.Random();

            for (int i = 0; i < 10; i++)
            {
                var title = $"Objetivo {i + 1}";
                var value = randomizer.NextDouble() * 100;

                gaugeItems.Add(new GaugeItem(value, series =>
                {
                    series.Name = title;
                    series.DataLabelsSize = 12;
                    series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.End;
                    series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue:F0}%";
                    series.InnerRadius = 16;
                    series.MaxRadialColumnWidth = 8;
                }));

                ConcreteBindingContext.ObjectiveOverviews.Add(new ObjectiveOverviewViewModel
                {
                    Index = i + 1,
                    Title = title,
                    ProyectionCount = i + 1,
                    ActionCount = (i + 1) * 4,
                    IndicatorCount = (i + 1) * 4 * 2,
                    ProgressChart = new ChartViewModel
                    {
                        Series = GaugeGenerator.BuildSolidGauge(new GaugeItem(value, series =>
                        {
                            series.MaxRadialColumnWidth = 50;
                            series.DataLabelsSize = 50;
                        })).ToArray()
                    },
                    ProgressGlyph = glyphs[randomizer.Next(0, 4)]
                });

                for (int j = 0; j < 12; j++)
                {
                    weightedPoints.Add(new LiveChartsCore.Defaults.WeightedPoint(i, j, randomizer.NextDouble() * 100));
                }
            }

            gaugeItems.Add(new GaugeItem(GaugeItem.Background, series =>
            {
                series.Fill = null;
            }));

            ConcreteBindingContext.GlobalObjectivesStatusChart.Series = GaugeGenerator.BuildSolidGauge(gaugeItems.ToArray()).ToArray();

            ConcreteBindingContext.MonthlyObjectivesProgressChart.Series = new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>[]
            {
                new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint> { Values = weightedPoints.ToArray() }
            };

            ConcreteBindingContext.ProyectionCount = 21;
            ConcreteBindingContext.ActionCount = ConcreteBindingContext.ProyectionCount * 4;
            ConcreteBindingContext.IndicatorCount = ConcreteBindingContext.ActionCount * 2;
        }
    }
}