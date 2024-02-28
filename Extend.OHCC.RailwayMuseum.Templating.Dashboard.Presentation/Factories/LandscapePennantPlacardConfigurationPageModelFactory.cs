using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapePennantPlacardConfigurationPageModelFactory
    {
        public static LandscapePennantPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new LandscapePennantPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapePennantPlacardContextModel>(placardViewModel.SerializedContext);

            return new LandscapePennantPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
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
