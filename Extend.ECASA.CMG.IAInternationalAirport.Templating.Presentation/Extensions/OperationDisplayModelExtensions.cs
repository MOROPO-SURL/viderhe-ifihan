using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using Xamarin.Forms;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class OperationDisplayModelExtensions
    {
        public static void AttachTo(this Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel target, int index, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind operationKind, StackLayout layout, ColumnDefinitionCollection columnDefinitions, Models.View.Placard.Contract.AbstractClassicOperationsPlacardViewModel model, Thickness margin, double fontSize, double timeColumnWidth, double gateColumnWidth)
        {
            var fontFamily = model.UseCondensedTextFontFamily ? "DIN Pro (Condensed Regular)" : "DIN Pro (Regular)";

            var useSecundaryColorProfile = model.UseStrippedRows && index % 2 != 0;

            var itemLayout = new Grid
            {
                ColumnSpacing = 2,
                ColumnDefinitions = columnDefinitions,
                BackgroundColor = useSecundaryColorProfile ? model.SecoundaryRowBackgroundColor : model.PrimaryRowBackgroundColor,
                VerticalOptions = LayoutOptions.Start,
                Opacity = 0
            };

            itemLayout.Behaviors.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Behaviors.BeginAnimationBehavior
            {
                Animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Direction = operationKind == Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival ? SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right : SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Left,
                    RelativeOffset = layout.Width,
                    Duration = "650",
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn
                }
            });

            if (model.Background != null)
            {
                itemLayout.BackgroundColor = itemLayout.BackgroundColor.MultiplyAlpha((100.0D - model.ForegroundTransparency) / 100);
            }

            var rowTextColor = useSecundaryColorProfile ? model.SecoundaryRowTextColor : model.PrimaryRowTextColor;

            for (int i = 0; i < model.Columns.Length; i++)
            {
                var column = model.Columns[i];

                switch (column)
                {
                    case ClassicOperationsColumn.TIME:
                        var time = target.PlannedAt;

                        if (target.EstimatedAt != null)
                        {
                            time = target.EstimatedAt.Value;
                        }

                        var timeLabel = new Label
                        {
                            Margin = margin,
                            WidthRequest = timeColumnWidth,
                            Text = time.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture),
                            TextColor = rowTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily
                        };

                        Grid.SetColumn(timeLabel, i);

                        itemLayout.Children.Add(timeLabel);

                        break;

                    case ClassicOperationsColumn.PLANNED_AT:
                        var plannedAtLabel = new Label
                        {
                            Margin = margin,
                            Text = target.PlannedAt.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture),
                            TextColor = rowTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily
                        };

                        Grid.SetColumn(plannedAtLabel, i);

                        itemLayout.Children.Add(plannedAtLabel);

                        break;

                    case ClassicOperationsColumn.ESTIMATED_AT:
                        var estimateAtLabel = new Label
                        {
                            Margin = margin,
                            Text = target.EstimatedAt?.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture) ?? "---",
                            TextColor = rowTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily
                        };

                        Grid.SetColumn(estimateAtLabel, i);

                        itemLayout.Children.Add(estimateAtLabel);

                        break;

                    case ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Context,
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(contextLabel, i);

                        itemLayout.Children.Add(contextLabel);

                        break;

                    case ClassicOperationsColumn.FLY:
                        var flyLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

                        flyLayout.Children.Add(new Views.BoxedCachedImage
                        {
                            Margin = new Thickness(margin.Left, 0, 0, 0),
                            Source = target.Carrier.Image == null ? ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", model.APIServer))) : target.Carrier.Image.ToImageSource(model)
                        });
                        flyLayout.Children.Add(new Label
                        {
                            Margin = margin,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Text = string.Format("{0} {1}", target.Carrier.Id, target.Flight),
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        });

                        Grid.SetColumn(flyLayout, i);

                        itemLayout.Children.Add(flyLayout);

                        break;

                    case ClassicOperationsColumn.CARRIER:
                        var carrierLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

                        carrierLayout.Children.Add(new Views.BoxedCachedImage
                        {
                            Margin = new Thickness(margin.Left, 0, 0, 0),
                            Source = target.Carrier.Image == null ? ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", model.APIServer))) : target.Carrier.Image.ToImageSource(model)
                        });
                        carrierLayout.Children.Add(new Label
                        {
                            Margin = margin,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Text = target.Carrier.Id,
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        });

                        Grid.SetColumn(carrierLayout, i);

                        itemLayout.Children.Add(carrierLayout);

                        break;

                    case ClassicOperationsColumn.FLYNUMBER:
                        var flyNumberLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Flight.ToString(),
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(flyNumberLabel, i);

                        itemLayout.Children.Add(flyNumberLabel);

                        break;

                    case ClassicOperationsColumn.CATEGORY:
                        var categoryLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Category.Name,
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(categoryLabel, i);

                        itemLayout.Children.Add(categoryLabel);

                        break;

                    case ClassicOperationsColumn.GATE:
                        var gateLabel = new Label
                        {
                            Margin = margin,
                            WidthRequest = gateColumnWidth,
                            Text = target.Gate,
                            TextColor = rowTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(gateLabel, i);

                        itemLayout.Children.Add(gateLabel);

                        break;

                    case ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Terminal.Name,
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(terminalLabel, i);

                        itemLayout.Children.Add(terminalLabel);

                        break;

                    case ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Status.Label,
                            TextColor = rowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize,
                            FontFamily = fontFamily,
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        Grid.SetColumn(statusLabel, i);

                        itemLayout.Children.Add(statusLabel);

                        break;
                }

                layout.Children.Add(itemLayout);
            };
        }
    }
}
