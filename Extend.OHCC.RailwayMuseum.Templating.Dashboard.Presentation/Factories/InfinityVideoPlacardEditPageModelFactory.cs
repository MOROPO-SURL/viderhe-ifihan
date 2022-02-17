using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class InfinityVideoPlacardEditPageModelFactory
    {
        public static Models.Page.InfinityVideoPlacardEditPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            var contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.InfinityVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.InfinityVideoPlacardEditPageModel
            {
                Label = placardViewModel.Label,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? Common.Templating.Dashboard.Presentation.Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                RequireUnobstructedPresetation = contextModel.RequireUnobstructedPresetation,
                Video = contextModel.Video.ToViewModel(),
                StartMargin = contextModel.StartMargin,
                EndMargin = contextModel.EndMargin
            };
        }
    }
}
