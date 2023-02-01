namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.FlatContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.TrailContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.TrailContextualOverlapForVideoTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
