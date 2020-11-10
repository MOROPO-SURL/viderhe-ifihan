namespace SmartSolucionesCuba.Videre.Extend.Essential.Overlaying.Dashboard.Presentation.Providers
{
    public class OverlayConfigurationPageProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetConfigurationPageByDescriptor(Common.Overlaying.Descriptors.IOverlayDescriptor overlayDescriptor, string serializedContext, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (overlayDescriptor.Id == Descriptors.SimpleHighlightsOverlayDescriptor.ID)
            {
                return new Pages.SimpleHighlightsOverlayConfigurationPage();
            }

            return null;
        }
    }
}
