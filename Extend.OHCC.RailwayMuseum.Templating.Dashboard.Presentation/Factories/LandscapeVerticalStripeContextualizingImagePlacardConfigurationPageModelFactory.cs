using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeVerticalStripeContextualizingImagePlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                IsContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                StripeColorBackgroundMode = context.StripeColorBackgroundMode,
                IsStripeBackgroundTranslucent = context.IsStripeBackgroundTranslucent,
                Header = context.Header,
                HeaderFontSize = context.HeaderFontSize,
                Content = context.Content,
                ContentFontSize = context.ContentFontSize
            };
        }
    }
}
