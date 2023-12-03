using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is TranslucentContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is FlatContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is TrailContextualOverlapForImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is TranslucentContextualOverlapForImageSecuenceTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is CenteredTraslucentIntroOverImageTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is TrailContextualOverlapForVideoTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is TranslucentContextualOverlapForVideoTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is FlatContextualOverlapForVideoTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is FlatContextualOverlapForImageSecuenceTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImageSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is TrailContextualOverlapForImageSecuenceTemplateDescriptor)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImageSecuencePlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == TranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == FlatContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.CenteredTraslucentIntroOverImagePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TranslucentContextualOverlapForVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == FlatContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.FlatContextualOverlapForImageSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == TrailContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Pages.Configuration.Placard.TrailContextualOverlapForImageSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
