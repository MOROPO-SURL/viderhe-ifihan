using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Pages;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (templateDescriptor is SimpleVideoTemplateDescriptor)
            {
                return new PrePickVideoPage(exceptionHandleHelper, templateDescriptor, completedActionCallback, (Support.Presentation.Models.View.VideoViewModel model, Extend.Common.Templating.Descriptors.ITemplateDescriptor _templateDescriptor, System.Action completeCallbackAction) =>
                {
                    Xamarin.Forms.Application.Current.MainPage.NavigationPushPageAsync(new CreateSimpleVideoPlacardPage(model, _templateDescriptor as SimpleVideoTemplateDescriptor, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completeCallbackAction));
                }, httpClientHelperProvider);
            }

            if (templateDescriptor is SimplePictureTemplateDescriptor)
            {
                return new SimplePicturePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is ResponsivePictureTemplateDescriptor)
            {
                return new ResponsivePicturePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is PictureSecuenceTemplateDescriptor)
            {
                return new PictureSecuencePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is LandscapePicturePresentingPictureTemplateDescriptor)
            {
                return new LandscapePicturePresentingPicturePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is LandscapePicturePresentingVideoTemplateDescriptor)
            {
                return new LandscapePicturePresentingVideoPlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is PortraitPicturePresentingPictureTemplateDescriptor)
            {
                return new PortraitPicturePresentingPicturePlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (templateDescriptor is PortraitPicturePresentingVideoTemplateDescriptor)
            {
                return new PortraitPicturePresentingVideoPlacardConfigurationPage(httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider, Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade notificationPresenter, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                return new SimplePicturePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                return new EditSimpleVideoPlacardPage(placardViewModel, cloudServerProvider, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == ResponsivePictureTemplateDescriptor.ID)
            {
                return new ResponsivePicturePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PictureSecuenceTemplateDescriptor.ID)
            {
                return new PictureSecuencePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                return new LandscapePicturePresentingPicturePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                return new LandscapePicturePresentingVideoPlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                return new PortraitPicturePresentingPicturePlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                return new PortraitPicturePresentingVideoPlacardConfigurationPage(placardViewModel, httpClientHelperProvider, exceptionHandleHelper, notificationPresenter, completedActionCallback);
            }

            return null;
        }
    }
}
