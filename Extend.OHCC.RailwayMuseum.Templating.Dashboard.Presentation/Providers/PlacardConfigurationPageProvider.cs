using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is InfinityVideoTemplateDescriptor)
            {
                return new Essential.Templating.Dashboard.Presentation.Pages.PrePickVideoPage(templateDescriptor, completedActionCallback, (Support.Presentation.Models.View.VideoViewModel model, Common.Templating.Descriptors.ITemplateDescriptor _templateDescriptor, System.Action completeCallbackAction) =>
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

            return null;
        }
    }
}
