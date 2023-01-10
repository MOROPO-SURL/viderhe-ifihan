namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Dashboard.Presentation.Factories
{
    public static class LandscapeGrid2x2PlacardConfigurationPageFactory
    {
        public static Models.Page.LandscapeGrid2x2PlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.LandscapeGrid2x2PlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.LandscapeGrid2x2PlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.LandscapeGrid2x2PlacardConfigurationPageModel
            {
                Label = placardViewModel.Label,
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
            };

            foreach (var item in context.OneOfFourTargetPlacards)
            {
                result.OneOfFourTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item as Support.Presentation.Models.View.PlacardViewModel, true));
            }

            foreach (var item in context.TwoOfFourTargetPlacards)
            {
                result.TwoOfFourTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item as Support.Presentation.Models.View.PlacardViewModel, true));
            }

            foreach (var item in context.ThreeOfFourTargetPlacards)
            {
                result.ThreeOfFourTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item as Support.Presentation.Models.View.PlacardViewModel, true));
            }

            foreach (var item in context.FourOfFourTargetPlacards)
            {
                result.FourOfFourTargetPlacards.Add(new Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel(item as Support.Presentation.Models.View.PlacardViewModel, true));
            }

            return result;
        }
    }
}
