namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor)
            {
                return new Pages.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor)
            {
                return new Pages.LandscapeContextualFlatOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor)
            {
                return new Pages.LandscapeContextualTrailOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.LandscapeContextualFlatOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.LandscapeContextualTrailOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
