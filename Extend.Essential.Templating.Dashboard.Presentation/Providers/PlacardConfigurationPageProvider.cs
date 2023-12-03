using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Pages;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is SimpleVideoTemplateDescriptor)
            {
                return new PrePickVideoPage(templateDescriptor, completedActionCallback, (model, _templateDescriptor, completeCallbackAction) =>
                {
                    Xamarin.Forms.Application.Current.MainPage.NavigationPushPageAsync(new CreateSimpleVideoPlacardPage(model, _templateDescriptor as SimpleVideoTemplateDescriptor, completeCallbackAction));
                });
            }

            if (templateDescriptor is SimplePictureTemplateDescriptor)
            {
                return new SimplePicturePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is PictureSlideSecuenceTemplateDescriptor)
            {
                return new PictureSlideSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapePicturePresentingPictureTemplateDescriptor)
            {
                return new LandscapePicturePresentingPicturePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapePicturePresentingVideoTemplateDescriptor)
            {
                return new LandscapePicturePresentingVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is PortraitPicturePresentingPictureTemplateDescriptor)
            {
                return new PortraitPicturePresentingPicturePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is PortraitPicturePresentingVideoTemplateDescriptor)
            {
                return new PortraitPicturePresentingVideoPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor)
            {
                return new LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor)
            {
                return new PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == SimplePictureTemplateDescriptor.ID)
            {
                return new SimplePicturePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == SimpleVideoTemplateDescriptor.ID)
            {
                return new EditSimpleVideoPlacardPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new PictureSlideSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                return new LandscapePicturePresentingPicturePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                return new LandscapePicturePresentingVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                return new PortraitPicturePresentingPicturePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                return new PortraitPicturePresentingVideoPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
