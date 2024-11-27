using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using Xamarin.Forms;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class AbstractClassicOperationsPlacardViewModelExtensions
    {
        public static void InitializeTableHeader(this Models.View.Placard.Contract.AbstractClassicOperationsPlacardViewModel target, Grid layout, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind operationKind, Thickness itemMargin, double itemFontSize, out Label timeSizeReferenceLabel, out Label gateSizeReferenceLabel)
        {
            var fontFamily = target.UseCondensedTextFontFamily ? "DIN Pro (Condensed Bold)" : "DIN Pro (Bold)";

            timeSizeReferenceLabel = new Label
            {
                Margin = itemMargin,
                Text = "HORA",
                TextColor = target.TableHeaderTextColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = itemFontSize,
                FontFamily = fontFamily,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            gateSizeReferenceLabel = new Label
            {
                Margin = itemMargin,
                Text = "PUERTA",
                TextColor = target.TableHeaderTextColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = itemFontSize,
                FontFamily = fontFamily,
                LineBreakMode = LineBreakMode.TailTruncation
            };

            foreach (var item in target.Columns)
            {
                switch (item)
                {
                    case ClassicOperationsColumn.TIME:
                    case ClassicOperationsColumn.GATE:
                        layout.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                        break;

                    case ClassicOperationsColumn.CONTEXT:
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
                    FontFamily = fontFamily,
                    LineBreakMode = LineBreakMode.TailTruncation
                };

                switch (item)
                {
                    case ClassicOperationsColumn.TIME:
                        Grid.SetColumn(timeSizeReferenceLabel, i);

                        layout.Children.Add(timeSizeReferenceLabel);

                        continue;

                    case ClassicOperationsColumn.GATE:
                        Grid.SetColumn(gateSizeReferenceLabel, i);

                        layout.Children.Add(gateSizeReferenceLabel);

                        continue;

                    case ClassicOperationsColumn.CONTEXT:
                        itemLabel.Text = operationKind == Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival ? "ORIGEN" : "DESTINO";

                        break;

                    case ClassicOperationsColumn.FLY:
                        itemLabel.Text = "VUELO";

                        break;

                    case ClassicOperationsColumn.TERMINAL:
                        itemLabel.Text = "TERMINAL";

                        break;

                    case ClassicOperationsColumn.STATUS:
                        itemLabel.Text = "CONDICION";

                        break;

                    case ClassicOperationsColumn.CARRIER:
                        itemLabel.Text = "AEROLINEA";

                        break;

                    case ClassicOperationsColumn.FLYNUMBER:
                        itemLabel.Text = "VUELO";

                        break;

                    case ClassicOperationsColumn.CATEGORY:
                        itemLabel.Text = "CATEGORIA";

                        break;

                    case ClassicOperationsColumn.PLANNED_AT:
                        itemLabel.Text = "HORA PLANIFICADA";

                        break;

                    case ClassicOperationsColumn.ESTIMATED_AT:
                        itemLabel.Text = "HORA ESTIMADA";

                        break;
                }

                Grid.SetColumn(itemLabel, i);

                layout.Children.Add(itemLabel);
            }
        }
    }
}
