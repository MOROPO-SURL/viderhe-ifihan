using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class GridExtensions
    {
        public static void InitializeAsTableHeader(this Grid target, Enumerations.ClassicOperationsColumn[] columns, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind operationKind, Thickness itemMargin, Color itemTextColor, double itemFontSize, out Label timeSizeReferenceLabel)
        {
            timeSizeReferenceLabel = new Label
            {
                Margin = itemMargin,
                Text = "HORA",
                TextColor = itemTextColor,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = itemFontSize,
                FontAttributes = FontAttributes.Bold
            };

            foreach (var item in columns)
            {
                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        target.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        target.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                        break;

                    default:
                        target.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

                        break;
                }
            }

            for (int i = 0; i < columns.Length; i++)
            {
                var item = columns[i];

                switch (item)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        Grid.SetColumn(timeSizeReferenceLabel, i);

                        target.Children.Add(timeSizeReferenceLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = operationKind == MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival ? "ORIGEN" : "DESTINO",
                            TextColor = itemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(contextLabel, i);

                        target.Children.Add(contextLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        var flyLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "VUELO",
                            TextColor = itemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(flyLabel, i);

                        target.Children.Add(flyLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "TERMINAL",
                            TextColor = itemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(terminalLabel, i);

                        target.Children.Add(terminalLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = itemMargin,
                            Text = "ESTADO",
                            TextColor = itemTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = itemFontSize,
                            FontAttributes = FontAttributes.Bold
                        };

                        Grid.SetColumn(statusLabel, i);

                        target.Children.Add(statusLabel);

                        break;
                }
            }
        }
    }
}
