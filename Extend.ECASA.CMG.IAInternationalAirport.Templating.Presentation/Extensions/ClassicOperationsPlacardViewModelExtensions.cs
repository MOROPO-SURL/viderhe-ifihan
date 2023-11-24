using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class ClassicOperationsPlacardViewModelExtensions
    {
        public static void InitializeTableHeader(this Models.View.Placard.ClassicOperationsPlacardViewModel target, Grid layout, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind operationKind, Thickness itemMargin, double itemFontSize, out Label timeSizeReferenceLabel)
        {
            timeSizeReferenceLabel = new Label
            {
                Margin = itemMargin,
                Text = "HORA",
                TextColor = target.TableHeaderTextColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = itemFontSize,
                FontAttributes = FontAttributes.Bold
            };

            foreach (var item in target.Columns)
            {
                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        layout.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                        break;

                    default:
                        layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

                        break;
                }
            }

            for (int i = 0; i < target.Columns.Length; i++)
            {
                var item = target.Columns[i];

                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        Grid.SetColumn(timeSizeReferenceLabel, i);

                        layout.Children.Add(timeSizeReferenceLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = operationKind == MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival ? "ORIGEN" : "DESTINO",
                            TextColor = target.TableHeaderTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(contextLabel, i);

                        layout.Children.Add(contextLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        var flyLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "VUELO",
                            TextColor = target.TableHeaderTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(flyLabel, i);

                        layout.Children.Add(flyLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "TERMINAL",
                            TextColor = target.TableHeaderTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(terminalLabel, i);

                        layout.Children.Add(terminalLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "ESTADO",
                            TextColor = target.TableHeaderTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(statusLabel, i);

                        layout.Children.Add(statusLabel);

                        break;
                }
            }
        }
    }
}
