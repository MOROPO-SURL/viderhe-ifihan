using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapePennantTrainPlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapePennantTrainPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapePennantTrainPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.LandscapePennantTrainPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.LandscapePennantTrainPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                ContextedImage = context.ContextedImage.ToViewModel(),
                IsContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                FlyoutShapeKind = context.FlyoutShapeKind,
                FlyoutBackgroundColorMode = context.FlyoutBackgroundColorMode,
                PennantVerticalOrientation = context.PennantVerticalOrientation,
                Header = context.Header,
                HeaderFontSize = context.HeaderFontSize,
                Content = context.Content,
                ContentFontSize = context.ContentFontSize
            };
        }
    }
}
