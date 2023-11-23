using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class OperationDisplayModelExtensions
    {
        public static void AttachTo(this MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel target, StackLayout layout, ColumnDefinitionCollection columnDefinitions, Models.View.Placard.ClassicOperationsPlacardViewModel model, Thickness margin, double fontSize, double timeColumnWidth)
        {
            var itemLayout = new Grid
            {
                ColumnSpacing = 2,
                ColumnDefinitions = columnDefinitions,
                BackgroundColor = model.PrimaryRowBackgroundColor,
                VerticalOptions = LayoutOptions.Start
            };

            for (int i = 0; i < model.Columns.Length; i++)
            {
                var column = model.Columns[i];

                switch (column)
                {
                    case Enumerations.ClassicOperationsColumn.TIME:
                        var timeLabel = new Label
                        {
                            Margin = margin,
                            WidthRequest = timeColumnWidth,
                            Text = target.StartDate.ToString("HH:mm"),
                            TextColor = model.PrimaryRowTextColor,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize
                        };

                        Grid.SetColumn(timeLabel, i);

                        itemLayout.Children.Add(timeLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.CONTEXT:
                        var contextLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Context,
                            TextColor = model.PrimaryRowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize
                        };

                        Grid.SetColumn(contextLabel, i);

                        itemLayout.Children.Add(contextLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.FLY:
                        var flyLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

                        flyLayout.Children.Add(new Views.BoxedCachedImage
                        {
                            Source = target.Carrier.Image == null ? ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/images/default-carrier.jpg", "http", model.APIServer))) : target.Carrier.Image.ToImageSource(model)
                        });
                        flyLayout.Children.Add(new Label
                        {
                            Margin = margin,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Text = string.Format("{0} {1}", target.Carrier.Id, target.Flight),
                            TextColor = model.PrimaryRowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize
                        });

                        Grid.SetColumn(flyLayout, i);

                        itemLayout.Children.Add(flyLayout);

                        break;

                    case Enumerations.ClassicOperationsColumn.TERMINAL:
                        var terminalLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Terminal.Name,
                            TextColor = model.PrimaryRowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize
                        };

                        Grid.SetColumn(terminalLabel, i);

                        itemLayout.Children.Add(terminalLabel);

                        break;

                    case Enumerations.ClassicOperationsColumn.STATUS:
                        var statusLabel = new Label
                        {
                            Margin = margin,
                            Text = target.Status.Label,
                            TextColor = model.PrimaryRowTextColor,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = fontSize
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
