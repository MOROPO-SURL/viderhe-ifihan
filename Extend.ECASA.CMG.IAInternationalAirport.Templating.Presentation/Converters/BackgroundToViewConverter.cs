using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Converters
{
    public class BackgroundToViewConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var target = value as BackgroundContextModel;

                switch (target.Kind)
                {
                    case BackgroundKind.Solid:
                        return new Views.Background.SolidBackgroundView(new Models.View.Background.SolidBackgroundViewModel { Color = Xamarin.Forms.Color.FromHex(target.SerializedContext) });

                    case BackgroundKind.Gradient:
                        var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(target.SerializedContext);

                        return new Views.Background.GradientBackgroundView(new Models.View.Background.GradientBackgroundViewModel { Source = MagicGradients.CssGradientSource.Parse(gradientModel.Data) });

                    case BackgroundKind.Image:
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
            //else
            //{
            //    DisposeCallbackAction?.Invoke();
            //}

            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
