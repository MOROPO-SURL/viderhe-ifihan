using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Pages;
using SmartSolucionesCuba.Videre.Extend.Essential.Templating.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Providers
{
    public static class TemplateConfigurationPageProvider
    {
        public static Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Extend.Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (templateDescriptor is SimpleVideoTemplateDescriptor)
            {
                return new Support.Presentation.Dashboard.Pages.VideoPickPage(exceptionHandleHelper, templateDescriptor, completedActionCallback, (Support.Presentation.Models.View.VideoViewModel model, Extend.Common.Templating.Descriptors.ITemplateDescriptor _templateDescriptor, System.Action completeCallbackAction) =>
                {
                    Xamarin.Forms.Application.Current.MainPage.NavigationPushPageAsync(new CreateSimpleVideoPlacardPage(model, _templateDescriptor as SimpleVideoTemplateDescriptor, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completeCallbackAction));
                }, Managers.SessionManager.Instance);
            }

            if (templateDescriptor is SimplePictureTemplateDescriptor)
            {
                return new SimplePicturePlacardConfigurationPage(Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (templateDescriptor is ResponsivePictureTemplateDescriptor)
            {
                return new ResponsivePicturePlacardConfigurationPage(Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (templateDescriptor is AbstractPhotoEventDescriptor)
            {
                return new PhotoEventPlacardConfigurationPage(Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, templateDescriptor as AbstractPhotoEventDescriptor, completedActionCallback);
            }

            if (templateDescriptor is PictureSecuenceTemplateDescriptor)
            {
                return new PictureSecuencePlacardConfigurationPage(Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            //if (templateDescriptor is InmersivePosterFilmProjectionTemplateDescriptor)
            //{
            //    return new InmersivePosterFilmProjectionPlacardConfigurationPage(ResourceProvider.Instance, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            //}

            return null;
        }

        public static Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                return new SimplePicturePlacardConfigurationPage(placardViewModel, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (placardViewModel.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                return new EditSimpleVideoPlacardPage(placardViewModel, CloudServerProvider.Instance, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (placardViewModel.Template.Id == ResponsivePictureTemplateDescriptor.ID)
            {
                return new ResponsivePicturePlacardConfigurationPage(placardViewModel, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (placardViewModel.Template.Id == FloatLeftDetailedPhotoEventTemplateDescriptor.ID)
            {
                return new PhotoEventPlacardConfigurationPage(placardViewModel, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PictureSecuenceTemplateDescriptor.ID)
            {
                return new PictureSecuencePlacardConfigurationPage(placardViewModel, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            }

            //if (placardViewModel.Template.Id == InmersivePosterFilmProjectionTemplateDescriptor.ID)
            //{
            //    return new InmersivePosterFilmProjectionPlacardConfigurationPage(placardViewModel, ResourceProvider.Instance, Managers.SessionManager.Instance, exceptionHandleHelper, Presenters.NotificationPresenter.Instance, completedActionCallback);
            //}

            return null;
        }
    }
}
