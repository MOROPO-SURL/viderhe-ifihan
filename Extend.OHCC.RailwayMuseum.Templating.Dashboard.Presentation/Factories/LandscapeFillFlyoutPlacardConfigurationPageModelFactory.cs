using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeFillFlyoutPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeFillFlyoutPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeFillFlyoutPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapeFillFlyoutPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapeFillFlyoutPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                ContextedImageLayoutMode = context.ContextedImageLayoutMode,
                IsContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                ContextedImageCenteredAtPresentation = context.ContextedImageCenteredAtPresentation,
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
