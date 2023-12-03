using MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Providers
{
    internal class PlacardViewModelCompletitionHelperProvider : Common.Templating.Presentation.Providers.Facade.IPlacardViewModelCompletitionHelperProviderFacade
    {
        public Common.Templating.Presentation.Helpers.Facade.IPlacardViewModelCompletitionHelperFacade GetFor(Cloud.Api.Common.Models.PlacardDisplayModel model)
        {
            if (model.Template.Id == LandscapeGrid1x3TemplateDescriptor.ID) return new Helpers.Grid1x3PlacardViewModelCompletitionHelper();

            if (model.Template.Id == LandscapeGrid2x2TemplateDescriptor.ID) return new Helpers.Grid2x2PlacardViewModelCompletitionHelper();

            return null;
        }
    }
}
