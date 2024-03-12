using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PictureSlideSecuencePlacardConfigurationPageModelFactory
    {
        public static PictureSlideSecuencePlacardConfigurationPageModel Build(PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new PictureSlideSecuencePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.PictureSlideSecuencePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new PictureSlideSecuencePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>(placardViewModel.Tags),
                PicturePresentationSecounds = context.PicturePresentationSecounds
            };

            foreach (var item in context.Slides)
            {
                result.Slides.Add(new Models.View.PictureSlideViewModel
                {
                    Image = new ImageViewModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                    LayoutMode = item.LayoutMode
                });
            }

            return result;
        }
    }
}
