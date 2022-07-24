namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.TranslucentContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.FlatContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.FlatContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.TrailContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.TrailContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor)
            {
                return new Pages.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor)
            {
                return new Pages.CenteredTraslucentIntroOverImagePlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.TranslucentContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.FlatContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.TrailContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Pages.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Pages.CenteredTraslucentIntroOverImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
