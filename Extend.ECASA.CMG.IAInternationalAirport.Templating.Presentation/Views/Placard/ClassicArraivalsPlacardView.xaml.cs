using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Placard
{
    public partial class ClassicArraivalsPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Facade.IInteroperablePlacardFacade, MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private readonly Models.View.Placard.ClassicOperationsPlacardViewModel model;

        private readonly ContentView header;
        private readonly BoxView separator;
        private readonly Grid tableHader;
        private readonly StackLayout tableBodyLayout;
        private readonly Label timeHeaderLabel;

        public ClassicArraivalsPlacardView(Models.View.Placard.ClassicOperationsPlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;

            #region Initilize UI
            ArraivalsLayout.Children.Add(header = new Fragment.ArraivalsHeaderFragmentView());
            ArraivalsLayout.Children.Add(separator = new BoxView 
            {
                HeightRequest = 4,
                Color = Color.LightCyan,
                Margin = new Thickness(0, 0, 0, 8)
            });
            ArraivalsLayout.Children.Add(tableHader = new Grid
            {
                BackgroundColor = model.TableHeaderBackgroundColor,
                ColumnSpacing = 0
            });
            ArraivalsLayout.Children.Add(tableBodyLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(0, 6, 0, 0)
            });

            foreach (var item in model.Columns)
            {
                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        tableHader.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        tableHader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                        break;

                    default:
                        tableHader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

                        break;
                }
            }
            
            var tableHeaderItemTextColor = model.TableHeaderTextColor;
            var tableHeaderItemFontSize = SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.TableHeaderFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

            for (int i = 0; i < model.Columns.Length; i++)
            {
                var item = model.Columns[i];

                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        tableHader.Children.Add(timeHeaderLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = "HORA",
                            TextColor = tableHeaderItemTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double) tableHeaderItemFontSize,
                            FontAttributes = FontAttributes.Bold
                        });

                        Grid.SetColumn(timeHeaderLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = "ORIGEN",
                            TextColor = tableHeaderItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double) tableHeaderItemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        tableHader.Children.Add(contextLabel);

                        Grid.SetColumn(contextLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        var flyLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = "VUELO",
                            TextColor = tableHeaderItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableHeaderItemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        tableHader.Children.Add(flyLabel);

                        Grid.SetColumn(flyLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = "TERMINAL",
                            TextColor = tableHeaderItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableHeaderItemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        tableHader.Children.Add(terminalLabel);

                        Grid.SetColumn(terminalLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = "ESTADO",
                            TextColor = tableHeaderItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableHeaderItemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        tableHader.Children.Add(statusLabel);

                        Grid.SetColumn(statusLabel, i);

                        break;
                }
            }
            #endregion

            this.model = model;
        }

        public override Layout<View> WrapLayout => Wrapper;

        public override View PlacardView => ArraivalsLayout;

        public override void ConfigureLayout(View view)
        {
            Grid.SetColumn(view, 0);
            Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
            }).ContinueWith(FetchOperations_Callback);
        }

        private Layout GetOperationView(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel context, ColumnDefinitionCollection tableColumnDefinitions, Color tableBodyItemTextColor)
        {
            var tableBodyItemFontSize = SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.RowFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

            var layout = new Grid
            {
                ColumnSpacing = 2,
                ColumnDefinitions = tableColumnDefinitions,
                BackgroundColor = model.PrimaryRowBackgroundColor
            };

            for (int i = 0; i < model.Columns.Length; i++)
            {
                var column = model.Columns[i];

                switch (column)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        var timeLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            WidthRequest = timeHeaderLabel.Width,
                            Text = context.StartDate.ToString("HH:mm"),
                            TextColor = tableBodyItemTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableBodyItemFontSize
                        };

                        layout.Children.Add(timeLabel);

                        Grid.SetColumn(timeLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = context.Context,
                            TextColor = tableBodyItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableBodyItemFontSize
                        };

                        layout.Children.Add(contextLabel);

                        Grid.SetColumn(contextLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        var flyLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

                        flyLayout.Children.Add(new BoxCachedImage
                        {
                            Source = context.Carrier.Image == null ? ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", model.APIServer))) : context.Carrier.Image.ToImageSource(model)
                        });
                        flyLayout.Children.Add(new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Text = string.Format("{0} {1}", context.Carrier.Id, context.Flight),
                            TextColor = tableBodyItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableBodyItemFontSize
                        });

                        layout.Children.Add(flyLayout);

                        Grid.SetColumn(flyLayout, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = context.Terminal.Name,
                            TextColor = tableBodyItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableBodyItemFontSize
                        };

                        layout.Children.Add(terminalLabel);

                        Grid.SetColumn(terminalLabel, i);

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = TABLE_ITEM_MARGIN,
                            Text = context.Status.Label,
                            TextColor = tableBodyItemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = (double)tableBodyItemFontSize
                        };

                        layout.Children.Add(statusLabel);

                        Grid.SetColumn(statusLabel, i);

                        break;
                }
            };

            return layout;
        }
        
        private void FetchOperations_Callback(System.Threading.Tasks.Task<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    tableBodyLayout.Children.Clear();
                });

                foreach (var item in task.Result)
                {
                    System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(250));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        tableBodyLayout.Children.Add(GetOperationView(item, tableHader.ColumnDefinitions, model.PrimaryRowTextColor));
                    });
                }
            }

            stopwatch.Stop();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(model.UpdateInterval) - stopwatch.Elapsed;

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                    }).ContinueWith(FetchOperations_Callback);
                });
            }
        }

        #region IInteroperablePlacardFacade implementation

        public Models.View.Placard.Contract.AbstractInteroperablePlacardViewModel GetInteroperableModel()
        {
            return BindingContext as Models.View.Placard.Contract.AbstractInteroperablePlacardViewModel;
        }

        #endregion

        #region IHttpClientHelperProviderFacade implementation

        public MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                return new MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", model.UseSSL ? "https" : "http", model.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; });
            }
        }

        #endregion
    }
}