using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class EditSimpleVideoPlacardPageModelFactory
    {
        public static EditSimpleVideoPlacardPageModel Build(PlacardViewModel placardViewModel)
        {
            var contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.SimpleVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new EditSimpleVideoPlacardPageModel
            {
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>(placardViewModel.Tags),
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                RequireUnobstructedPresetation = contextModel.RequireUnobstructedPresetation,
                Video = contextModel.Video.ToViewModel()
            };
        }
    }
}
