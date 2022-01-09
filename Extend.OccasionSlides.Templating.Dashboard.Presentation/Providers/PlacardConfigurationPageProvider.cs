namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor)
            {
                return new Pages.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor)
            {
                return new Pages.LandscapeContextualFlatOverlapForImagePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                return new Pages.LandscapeContextualFlatOverlapForImagePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            return null;
        }
    }
}
