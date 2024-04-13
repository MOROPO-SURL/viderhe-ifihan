using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Placard;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Placard
{
    public static class TranslucentContextualOverlapForImagePlacardConfigurationPageModelFactory
    {
        public static TranslucentContextualOverlapForImagePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new TranslucentContextualOverlapForImagePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<TranslucentContextualOverlapForImagePlacardContextModel>(placardViewModel.SerializedContext, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });

            var result = new TranslucentContextualOverlapForImagePlacardConfigurationPageModel
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
                ContextedImageZoomingEnabled = context.ContextedImageZoomingEnabled,
                ContextedImageLayoutMode = context.ContextedImageAspectToFitAndComplementFilled ? Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf : Essential.Templating.Enumerations.PictureLayoutMode.AspectFill,
                OverlapSize = context.OverlapSize,
                OverlapShapeKind = context.OverlapShapeKind,
                OverlapBackgroundColor = Xamarin.Forms.Color.FromHex(context.OverlapBackgroundColor),
                OverlapAlignment = context.OverlapAlignment,
                IsOverlapAnchoredAtVertical = context.IsOverlapAnchoredAtVertical
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
