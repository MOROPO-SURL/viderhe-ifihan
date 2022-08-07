using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Converters
{
    public class BackgroundToViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var target = value as Templating.Models.Context.BackgroundContextModel;

                switch (target.Kind)
                {
                    case Enumerations.BackgroundKind.Solid:
                        return new Views.Background.SolidBackgroundView(new Models.View.Background.SolidBackgroundViewModel { Color = Xamarin.Forms.Color.FromHex(target.SerializedContext) });

                    case Enumerations.BackgroundKind.Gradient:
                        return new Views.Background.GradientBackgroundView(new Models.View.Background.GradientBackgroundViewModel { Source = MagicGradients.CssGradientSource.Parse(target.SerializedContext) });

                    case Enumerations.BackgroundKind.Image:
                        var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(target.SerializedContext).ToViewModel();

                        return new Views.Background.ImageBackgroundView(new Models.View.Background.ImageBackgroundViewModel
                        {
                            Source = Support.Presentation.Factories.ImageUriFactory.BuildImageUri(imageModel.Id)
                        });

                    //case Enumerations.BackgroundKind.Video:
                    //    var videoModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.VideoContextModel>(target.SerializedContext).ToViewModel();


                    //    return new Models.View.Background.VideoBackgroundViewModel
                    //    {
                    //        Source = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(videoModel.Id, videoModel.Extension).AbsoluteUri)
                    //    };
                }
            }

            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
