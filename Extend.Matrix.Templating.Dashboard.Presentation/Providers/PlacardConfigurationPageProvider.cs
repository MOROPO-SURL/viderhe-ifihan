using MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is LandscapeGrid1x3TemplateDescriptor)
            {
                return new Pages.LandscapeGrid1x3PlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeGrid2x2TemplateDescriptor)
            {
                return new Pages.LandscapeGrid2x2PlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeGrid2x1TemplateDescriptor)
            {
                return new Pages.LandscapeGrid2x1PlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeGrid3st_2x1TemplateDescriptor)
            {
                return new Pages.LandscapeGrid3st_2x1PlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == LandscapeGrid1x3TemplateDescriptor.ID)
            {
                return new Pages.LandscapeGrid1x3PlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeGrid2x2TemplateDescriptor.ID)
            {
                return new Pages.LandscapeGrid2x2PlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeGrid2x1TemplateDescriptor.ID)
            {
                return new Pages.LandscapeGrid2x1PlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeGrid3st_2x1TemplateDescriptor.ID)
            {
                return new Pages.LandscapeGrid3st_2x1PlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
