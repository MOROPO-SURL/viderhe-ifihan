using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Dashboard.Presentation.Factories
{
    public class GovDecisorPrototype2PlacardConfigurationPageModelFactory
    {
        public static GovDecisorPrototype2PlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new GovDecisorPrototype2PlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.GovDecisorPrototype2PlacardContextModel>(placardViewModel.SerializedContext);

            return new GovDecisorPrototype2PlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                PlayerOrientationSupportKind = placardViewModel.PlayerOrientationSupportKind == null ? Common.Templating.Dashboard.Presentation.Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited : placardViewModel.PlayerOrientationSupportKind.Value.ToConfiguration(),
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds)
            };
        }
    }
}