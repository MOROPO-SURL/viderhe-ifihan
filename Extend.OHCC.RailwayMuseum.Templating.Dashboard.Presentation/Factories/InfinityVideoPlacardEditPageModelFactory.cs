using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories
{
    public static class InfinityVideoPlacardEditPageModelFactory
    {
        public static Models.Page.InfinityVideoPlacardEditPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            var contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<InfinityVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.InfinityVideoPlacardEditPageModel
            {
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? Common.Templating.Dashboard.Presentation.Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                RequireUnobstructedPresetation = contextModel.RequireUnobstructedPresetation,
                Video = contextModel.Video.ToViewModel(),
                StartMargin = contextModel.StartMargin,
                EndMargin = contextModel.EndMargin
            };
        }
    }
}
