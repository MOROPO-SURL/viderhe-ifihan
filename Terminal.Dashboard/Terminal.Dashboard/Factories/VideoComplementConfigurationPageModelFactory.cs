using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class VideoComplementConfigurationPageModelFactory
    {
        public static Models.Page.VideoComplementConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.ComplementationKind == null) return new Models.Page.VideoComplementConfigurationPageModel();

            if (model.ComplementationKind != Cloud.Persistence.Enumerations.PlacardComplementationKind.Video) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.VideoComplementContextModel>(model.SerializedComplementation);

            return new Models.Page.VideoComplementConfigurationPageModel
            {
                Video = context.Video.ToViewModel(),
                Position = context.Position,
                Delay = context.Delay
            };
        }
    }
}
