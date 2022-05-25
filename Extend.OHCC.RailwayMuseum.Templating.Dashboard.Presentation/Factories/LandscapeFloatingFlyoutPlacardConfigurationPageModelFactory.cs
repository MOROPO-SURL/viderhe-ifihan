using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeFloatingFlyoutPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeFloatingFlyoutPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeFloatingFlyoutPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeFloatingFlyoutPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapeFloatingFlyoutPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                IsContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                FlyoutShapeKind = context.FlyoutShapeKind,
                FlyoutBackgroundColorMode = context.FlyoutBackgroundColorMode,
                FlyoutHorizontalOrientation = context.FlyoutHorizontalOrientation,
                Header = context.Header,
                HeaderFontSize = context.HeaderFontSize,
                Content = context.Content,
                ContentFontSize = context.ContentFontSize
            };
        }
    }
}
