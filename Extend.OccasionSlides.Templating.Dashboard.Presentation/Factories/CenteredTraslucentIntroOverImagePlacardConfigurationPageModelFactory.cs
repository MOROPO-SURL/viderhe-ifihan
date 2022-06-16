using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class CenteredTraslucentIntroOverImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                HeaderImage = context.HeadImage?.ToViewModel(),
                BackgroundImage = context.BackgroundImage.ToViewModel(),
                BackgroundImageZoomingEnabled = context.BackgroundImageZoomingEnabled,
                OverlapOpacity = System.Convert.ToInt32(context.OverlapOpacity * 100),
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                ContentBoxPresentationKind = context.ContentBoxPresentationKind,
                Title = context.Title,
                TitleFontFamily = context.TitleFontFamily,
                TitleFontSize = context.TitleFontSize
            };

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(item.ToViewModel());
                }
            }

            return result;
        }
    }
}
