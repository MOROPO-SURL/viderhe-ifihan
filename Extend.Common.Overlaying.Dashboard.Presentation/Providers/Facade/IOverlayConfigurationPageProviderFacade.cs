namespace SmartSolucionesCuba.Videre.Extend.Common.Overlaying.Dashboard.Presentation.Providers.Facade
{
    public interface IOverlayConfigurationPageProviderFacade
    {
        Xamarin.Forms.Page GetConfigurationPageByDescriptor(Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback);
    }
}
