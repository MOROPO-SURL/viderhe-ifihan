using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using Mapsui.Extensions;
using Mapsui.Tiling;
using Mapsui.Utilities;
using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Models.View;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Views
{
    public partial class GovDecisorPrototype2PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public GovDecisorPrototype2PlacardView(GovDecisorPrototype2PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;
        }

        private GovDecisorPrototype2PlacardViewModel ConcreteBindingContext => BindingContext as GovDecisorPrototype2PlacardViewModel;

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var cloudServerProvider = Xamarin.Forms.DependencyService.Get<Support.Presentation.Providers.Facade.ICloudServerProviderFacade>();

            var extensionDirectory = new System.IO.FileInfo(GetType().Assembly.Location).Directory;

            var center = new Mapsui.MPoint(-77.9115, 21.3851);

            var map = new Mapsui.Map();

            var tileLayer = OpenStreetMap.CreateTileLayer();

            map.Layers.Add(new Mapsui.Tiling.Layers.TileLayer(new BruTile.MbTiles.MbTilesTileSource(new SQLite.SQLiteConnectionString(System.IO.Path.Combine(extensionDirectory.FullName, "map.mbtiles"), true))));
            map.Layers.Add(BuildPlacesLayer());

            map.Widgets.Add(new Mapsui.Widgets.ScaleBar.ScaleBarWidget(map)
            {
                TextAlignment = Mapsui.Widgets.Alignment.Center,
                HorizontalAlignment = Mapsui.Widgets.HorizontalAlignment.Left,
                VerticalAlignment = Mapsui.Widgets.VerticalAlignment.Bottom
            });

            map.Home = _map => _map.CenterOnAndZoomTo(Mapsui.Projections.SphericalMercator.FromLonLat(center), _map.Resolutions[9]);

            MainMapView.Map = map;

            ConcreteBindingContext.StatusChart.Series = GaugeGenerator.BuildSolidGauge(new GaugeItem(
                74,          // the gauge value
                series =>    // the series style
                {
                    series.MaxRadialColumnWidth = 15;
                    series.DataLabelsSize = 50;
                })).ToArray();

            ConcreteBindingContext.ProgressionChart.Series = new StepLineSeries<double>[]
            {
                new StepLineSeries<double>
                {
                    Values = new double[] { 2, -1, 1, 3, 0, -2, 4, 5, 7, 4.5, 5, 7, 8 },
                    Fill = null,
                    GeometrySize = 8
                }
            }.ToArray();

            ConcreteBindingContext.ProyectionCount = 7;
            ConcreteBindingContext.ActionCount = ConcreteBindingContext.ProyectionCount * 4;
            ConcreteBindingContext.IndicatorCount = ConcreteBindingContext.ActionCount * 2;

            var gaugeItems = new List<GaugeItem>();

            var weightedPoints = new List<LiveChartsCore.Defaults.WeightedPoint>();

            var randomizer = new System.Random();

            var specificObjectives = new System.Collections.Generic.List<SpecificObjectiveModel>();

            for (int i = 0; i < ConcreteBindingContext.ProyectionCount; i++)
            {
                var title = $"Objetivo Specífico {i + 1}";
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

                var trend = 100;
                var randomValues = new List<int>();

                var _random = new System.Random();

                for (var _i = 0; _i < 100; _i++)
                {
                    trend += _random.Next(-65, 125);

                    randomValues.Add(System.Math.Max(trend, 0));
                }

                specificObjectives.Add(new SpecificObjectiveModel
                {
                    Index = i + 1,
                    Name = title,
                    ObjectiveIndex = 3,
                    Actions = new ActionModel[] 
                    {
                        new ActionModel
                        {
                            Index = 1,
                            SpecificObjectiveIndex = i + 1,
                            ObjectiveIndex = 3,
                            Name = "Acción 1",
                            ProgressionChart = new ChartViewModel
                            {
                                Series = new ISeries[]
                                {
                                    new ColumnSeries<int> { Values = randomValues.ToArray() }
                                }
                            }
                        },
                        new ActionModel
                        {
                            Index = 2,
                            SpecificObjectiveIndex = i + 1,
                            ObjectiveIndex = 3,
                            Name = "Acción 2",
                            ProgressionChart = new ChartViewModel
                            {
                                Series = new ISeries[]
                                {
                                    new ColumnSeries<int> { Values = randomValues.ToArray() } 
                                }
                            }
                        }
                    }
                });
            }

            gaugeItems.Add(new GaugeItem(GaugeItem.Background, series =>
            {
                series.Fill = null;
            }));

            ConcreteBindingContext.ProyectionsStatusChart.Series = GaugeGenerator.BuildSolidGauge(gaugeItems.ToArray()).ToArray();

            ConcreteBindingContext.SpecificObjectives = specificObjectives.ToArray();

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(5)).ContinueWith(task =>
            {
                var featureAreaPoints = new Mapsui.MPoint[] 
                { 
                    new Mapsui.MPoint(-77.9966617606413, 21.6124974279441), 
                    new Mapsui.MPoint(-78.2552, 21.2016), 
                    new Mapsui.MPoint(-77.4415, 21.498), 
                    new Mapsui.MPoint(-77.8037, 20.9128) 
                };

                foreach (var item in featureAreaPoints)
                {
                    Dispatcher.BeginInvokeOnMainThread(() => { MainMapView.Map.Navigator.CenterOnAndZoomTo(Mapsui.Projections.SphericalMercator.FromLonLat(item), MainMapView.Map.Navigator.Resolutions[11], 500, Mapsui.Animations.Easing.CubicOut); });

                    System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(10));

                    Dispatcher.BeginInvokeOnMainThread(() => { MainMapView.Map.Navigator.ZoomOut(500, Mapsui.Animations.Easing.CubicOut); });

                    System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(5));
                }

                Dispatcher.BeginInvokeOnMainThread(() => { MainMapView.Map.Navigator.CenterOnAndZoomTo(Mapsui.Projections.SphericalMercator.FromLonLat(center), MainMapView.Map.Navigator.Resolutions[9], 500, Mapsui.Animations.Easing.CubicOut); });
            });
        }
        private Mapsui.Layers.MemoryLayer BuildPlacesLayer()
        {
            var featurePlacePointStyle = new Mapsui.Styles.SymbolStyle { SymbolType = Mapsui.Styles.SymbolType.Triangle, SymbolRotation = 180, SymbolScale = 1.0, Fill = new Mapsui.Styles.Brush(Mapsui.Styles.Color.OrangeRed) };

            var featurePlacePoints = new Mapsui.MPoint[] 
            { 
                new Mapsui.MPoint(-78.0161032046285, 21.6806088418101),
                new Mapsui.MPoint(-77.8919770622491, 21.6389117901297),
                new Mapsui.MPoint(-77.9637608554324, 21.6806088418101),
                new Mapsui.MPoint(-78.1821032263646, 21.2881829656663),
                new Mapsui.MPoint(-78.1880852091299, 21.1878202219215),
                new Mapsui.MPoint(-77.353598613375, 21.5561770304186),
                new Mapsui.MPoint(-77.3790220401274, 21.4573897364596),
                new Mapsui.MPoint(-77.4597788074585, 21.5422673896359),
                new Mapsui.MPoint(-77.5584815230854, 21.5450494244686),
                new Mapsui.MPoint(-77.7319590232782, 20.9051857380532),
                new Mapsui.MPoint(-77.7678509198698, 20.8297260603248)
            };

            return new Mapsui.Layers.MemoryLayer
            {
                Name = "Lugares",
                IsMapInfoLayer = false,
                Style = null,
                Features = featurePlacePoints.Select(item =>
                {
                    var result = new Mapsui.Layers.PointFeature(Mapsui.Projections.SphericalMercator.FromLonLat(item));

                    result.Styles.Add(featurePlacePointStyle);

                    return result;
                }).ToArray(),
            };
        }
    }
}