using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public static class CenteredTraslucentIntroOverImagePlacardConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.CenteredTraslucentIntroOverImagePlacardContextModel>(placardViewModel.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            var result = new Models.Page.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                HeaderImage = context.HeadImage?.ToViewModel(),
                BackgroundImage = context.BackgroundImage.ToViewModel(),
                BackgroundImageZoomingEnabled = context.BackgroundImageZoomingEnabled,
                OverlapOpacity = System.Convert.ToInt32(context.OverlapOpacity * 100),
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                ContentBoxPresentationKind = context.ContentBoxPresentationKind
            };

            if (context.ContentBlocks != null)
            {
                foreach (var item in context.ContentBlocks)
                {
                    result.ContentBlocks.Add(new Models.View.ContentBlockCollectionItemViewModel { Target = item.ToViewModel() });
                }
            }

            return result;
        }
    }
}
