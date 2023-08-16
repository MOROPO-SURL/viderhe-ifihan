using SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeGrid1x3PlacardConfigurationPageFactory
    {
        public static Models.Page.LandscapeGrid1x3PlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeGrid1x3PlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid1x3PlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeGrid1x3PlacardConfigurationPageModel
            {
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
            };

            foreach (var item in context.OneOfThreeTargetPlacards)
            {
                result.OneOfThreeTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item.ToPlacardViewModel(), true));
            }

            foreach (var item in context.TwoOfThreeTargetPlacards)
            {
                result.TwoOfThreeTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item.ToPlacardViewModel(), true));
            }

            foreach (var item in context.ThreeOfThreeTargetPlacards)
            {
                result.ThreeOfThreeTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item.ToPlacardViewModel(), true));
            }

            return result;
        }
    }
}
