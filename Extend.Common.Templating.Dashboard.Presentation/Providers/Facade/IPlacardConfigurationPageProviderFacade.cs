namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade
{
    public interface IPlacardConfigurationPageProviderFacade
    {
        Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Descriptors.ITemplateDescriptor templateDescriptor, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback);

        Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback);
    }
}
