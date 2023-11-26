using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class ClassicOperationsPlacardViewModelExtensions
    {
        public static void InitializeTableHeader(this Models.View.Placard.ClassicOperationsPlacardViewModel target, Grid layout, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind operationKind, Thickness itemMargin, double itemFontSize, out Label timeSizeReferenceLabel, out Label gateSizeReferenceLabel)
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

            gateSizeReferenceLabel = new Label
            {
                Margin = itemMargin,
                Text = "PUERTA",
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
                    case Enumerations.ClassicOperationsColumn.GATE:
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

                var itemLabel = new Label
                {
                    Margin = itemMargin,
                    TextColor = target.TableHeaderTextColor,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = itemFontSize,
                    FontAttributes = FontAttributes.Bold,
                    LineBreakMode = LineBreakMode.TailTruncation
                };

                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        Grid.SetColumn(timeSizeReferenceLabel, i);

                        layout.Children.Add(timeSizeReferenceLabel);

                        continue;

                    case Enumerations.ClassicOperationsColumn.GATE:
                        Grid.SetColumn(gateSizeReferenceLabel, i);

                        layout.Children.Add(gateSizeReferenceLabel);

                        continue;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        itemLabel.Text = operationKind == MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival ? "ORIGEN" : "DESTINO";

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        itemLabel.Text = "VUELO";

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        itemLabel.Text = "TERMINAL";

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        itemLabel.Text = "ESTADO";

                        break;

                    case Enumerations.ClassicOperationsColumn.CARRIER:
                        itemLabel.Text = "AEROLINEA";

                        break;

                    case Enumerations.ClassicOperationsColumn.FLYNUMBER:
                        itemLabel.Text = "VUELO";

                        break;

                    case Enumerations.ClassicOperationsColumn.CATEGORY:
                        itemLabel.Text = "CATEGORIA";

                        break;
                }

                Grid.SetColumn(itemLabel, i);

                layout.Children.Add(itemLabel);
            }
        }
    }
}
