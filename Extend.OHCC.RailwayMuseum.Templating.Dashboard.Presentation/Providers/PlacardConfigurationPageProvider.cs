using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is InfinityVideoTemplateDescriptor)
            {
                return new Essential.Templating.Dashboard.Presentation.Pages.PrePickVideoPage(templateDescriptor, completedActionCallback, (model, _templateDescriptor, completeCallbackAction) =>
                {
                    Xamarin.Forms.Application.Current.MainPage.NavigationPushPageAsync(new Pages.InfinityVideoPlacardCreatePage(model, _templateDescriptor as InfinityVideoTemplateDescriptor, completeCallbackAction));
                });
            }

            if (templateDescriptor is CornerTileVideoPresentingVideoTemplateDescriptor)
            {
                return new Pages.CornerTileVideoPresentingVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeCrossStripeTemplateDescriptor)
            {
                return new Pages.LandscapeCrossStripePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeFramedTemplateDescriptor)
            {
                return new Pages.LandscapeFramedPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapePennantTemplateDescriptor)
            {
                return new Pages.LandscapePennantPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeFloatingFlyoutTemplateDescriptor)
            {
                return new Pages.LandscapeFloatingFlyoutPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeAnonimusHeroTemplateDescriptor)
            {
                return new Pages.LandscapeAnonimusHeroPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapeFillFlyoutTemplateDescriptor)
            {
                return new Pages.LandscapeFillFlyoutPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == InfinityVideoTemplateDescriptor.ID)
            {
                return new Pages.InfinityVideoPlacardEditPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                return new Pages.CornerTileVideoPresentingVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeCrossStripeTemplateDescriptor.ID)
            {
                return new Pages.LandscapeCrossStripePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeFramedTemplateDescriptor.ID)
            {
                return new Pages.LandscapeFramedPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePennantTemplateDescriptor.ID)
            {
                return new Pages.LandscapePennantPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeFloatingFlyoutTemplateDescriptor.ID)
            {
                return new Pages.LandscapeFloatingFlyoutPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeAnonimusHeroTemplateDescriptor.ID)
            {
                return new Pages.LandscapeAnonimusHeroPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapeFillFlyoutTemplateDescriptor.ID)
            {
                return new Pages.LandscapeFillFlyoutPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
