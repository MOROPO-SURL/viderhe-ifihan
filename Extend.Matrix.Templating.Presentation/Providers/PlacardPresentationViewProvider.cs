using MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Matrix.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id == LandscapeGrid1x3TemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeGrid1x3PlacardContextModel>(model.SerializedContext);

                return new Views.LandscapeGrid1x3PlacardView(new Models.View.LandscapeGrid1x3PlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    OneOfThreeTargetPlacards = context.OneOfThreeTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    TwoOfThreeTargetPlacards = context.TwoOfThreeTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    ThreeOfThreeTargetPlacards = context.ThreeOfThreeTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    ScreenTimeDirectorScreenplayIndex = context.ScreenTimeDirectorScreenplayIndex
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == LandscapeGrid2x2TemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeGrid2x2PlacardContextModel>(model.SerializedContext);

                return new Views.LandscapeGrid2x2PlacardView(new Models.View.LandscapeGrid2x2PlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    OneOfFourTargetPlacards = context.OneOfFourTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    TwoOfFourTargetPlacards = context.TwoOfFourTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    ThreeOfFourTargetPlacards = context.ThreeOfFourTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    FourOfFourTargetPlacards = context.FourOfFourTargetPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    ScreenTimeDirectorScreenplayIndex = context.ScreenTimeDirectorScreenplayIndex
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == LandscapeGrid2x1TemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeGrid2x1PlacardContextModel>(model.SerializedContext);

                return new Views.LandscapeGrid2x1PlacardView(new Models.View.LandscapeGrid2x1PlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    TopCellPlacards = context.TopCellPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    IsTopCellPlacardsScalable = context.IsTopCellPlacardsScalable,
                    BottomCellPlacards = context.BottomCellPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    IsBottomCellPlacardsScalable = context.IsBottomCellPlacardsScalable,
                    ScreenTimeDirectorScreenplayIndex = context.ScreenTimeDirectorScreenplayIndex
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == LandscapeGrid3st_2x1TemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<LandscapeGrid3st_2x1PlacardContextModel>(model.SerializedContext);

                return new Views.LandscapeGrid3st_2x1PlacardView(new Models.View.LandscapeGrid3st_2x1PlacardViewModel
                {
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    TopCellPlacards = context.TopCellPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    IsTopCellPlacardsScalable = context.IsTopCellPlacardsScalable,
                    BottomLeftCellPlacards = context.BottomLeftCellPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    BottomRightCellPlacards = context.BottomRightCellPlacards.Select(item => item.ToPlacardViewModel()).ToArray(),
                    ScreenTimeDirectorScreenplayIndex = context.ScreenTimeDirectorScreenplayIndex
                }, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}
