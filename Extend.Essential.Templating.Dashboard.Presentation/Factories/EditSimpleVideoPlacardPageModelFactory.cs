using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class EditSimpleVideoPlacardPageModelFactory
    {
        public static Models.Page.EditSimpleVideoPlacardPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            var contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.EditSimpleVideoPlacardPageModel
            {
                Label = placardViewModel.Label,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? Common.Templating.Dashboard.Presentation.Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                RequireUnobstructedPresetation = contextModel.RequireUnobstructedPresetation,
                Video = contextModel.Video.ToViewModel()
            };
        }
    }
}
