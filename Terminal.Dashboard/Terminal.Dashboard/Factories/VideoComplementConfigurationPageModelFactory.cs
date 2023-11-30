using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class VideoComplementConfigurationPageModelFactory
    {
        public static Models.Page.VideoComplementConfigurationPageModel Build(PlacardViewModel model)
        {
            if (model.ComplementationKind == null) return new Models.Page.VideoComplementConfigurationPageModel();

            if (model.ComplementationKind != PlacardComplementationKind.Video) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoComplementContextModel>(model.SerializedComplementation);

            return new Models.Page.VideoComplementConfigurationPageModel
            {
                Video = context.Video.ToViewModel(),
                Position = context.Position,
                Delay = context.Delay
            };
        }
    }
}
