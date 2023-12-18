using MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeGrid2x1PlacardConfigurationPageModelFactory
    {
        public static Models.Page.LandscapeGrid2x1PlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeGrid2x1PlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid2x1PlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeGrid2x1PlacardConfigurationPageModel
            {
                Label = placardViewModel.Label,
                Tags = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>(placardViewModel.Tags),
                DefineBeginAt = placardViewModel.BeginAt != null,
                BeginAt = placardViewModel.BeginAt ?? System.DateTime.Now.Date,
                DefineEndAt = placardViewModel.EndAt != null,
                EndAt = placardViewModel.EndAt ?? System.DateTime.Now.Date,
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                IsOneOfTwoTargetPlacardsScalable = context.IsOneOfTwoTargetPlacardsScalable,
                IsTwoOfTwoTargetPlacardsScalable = context.IsTwoOfTwoTargetPlacardsScalable
            };

            foreach (var item in context.OneOfTwoTargetPlacards)
            {
                result.OneOfTwoTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item.ToPlacardViewModel(), true));
            }

            foreach (var item in context.TwoOfTwoTargetPlacards)
            {
                result.TwoOfTwoTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item.ToPlacardViewModel(), true));
            }

            return result;
        }
    }
}
