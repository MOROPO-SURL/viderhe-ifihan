using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
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
                var title = $"Obj. {i + 1}";
                var value = randomizer.NextDouble() * 100;

                gaugeItems.Add(new GaugeItem(value, series => 
                {
                    series.Name = title;
                    //series.DataLabelsSize = 12;
                    series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Start;
                    series.DataLabelsFormatter = point => $"{point.Context.Series.Name} {point.Coordinate.PrimaryValue:F0}%";
                    series.InnerRadius = 24;
                    series.RelativeOuterRadius = 4;
                    series.RelativeInnerRadius = 4;
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
                series.InnerRadius = 20;
            }));

            ConcreteBindingContext.GlobalObjectivesStatusChart.Series = GaugeGenerator.BuildSolidGauge(gaugeItems.ToArray()).ToArray();

            ConcreteBindingContext.MonthlyObjectivesProgressChart.Series = new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint>[]
            {
                new LiveChartsCore.SkiaSharpView.HeatSeries<LiveChartsCore.Defaults.WeightedPoint> { Values = weightedPoints.ToArray() }
            };

            ConcreteBindingContext.ProyectionCount = 21;
            ConcreteBindingContext.ActionCount = ConcreteBindingContext.ProyectionCount * 4;
            ConcreteBindingContext.IndicatorCount = ConcreteBindingContext.ActionCount * 2;

            var indexer = 0;

            var objectiveLabels = new string[] { "Objetivo 1", "Objetivo 2", "Objetivo 3", "Objetivo 4", "Objetivo 5", "Objetivo 6", "Objetivo 7", "Objetivo 8", "Objetivo 9", "Objetivo 10" };

            ConcreteBindingContext.ProyectionDistributionChart.Series = new[] { 8, 6, 5, 3, 3, 4, 7, 2, 10, 12 }.AsPieSeries((value, series) =>
            {
                series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                series.DataLabelsSize = 12;
                series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
            }).ToArray();

            ConcreteBindingContext.ActionDistributionChart.Series = new[] { 18, 26, 5, 13, 18, 21, 11, 12, 10, 24 }.AsPieSeries((value, series) =>
            {
                series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                series.DataLabelsSize = 12;
                series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
            }).ToArray();

            ConcreteBindingContext.IndicatorDistributionChart.Series = new[] { 24, 26, 8, 13, 19, 27, 12, 12, 20, 24 }.AsPieSeries((value, series) =>
            {
                series.Name = objectiveLabels[indexer++ % objectiveLabels.Length];
                series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
                series.DataLabelsSize = 12;
                series.DataLabelsPaint = new SolidColorPaint(new SkiaSharp.SKColor(30, 30, 30));
                series.DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} ({point.Coordinate.PrimaryValue / point.StackedValue.Total * 100:F0}%)";
            }).ToArray();
        }
    }
}