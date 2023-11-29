using MOROPO.VIDERHE.Support.Presentation.Helpers;
using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;

namespace MOROPO.VIDERHE.Support.Presentation.Factories
{
    public static class ImageUriFactory
    {
        public static System.Uri BuildImageUri(System.Guid imageId)
        {
            return new System.Uri(ImageUriFactoryHelper.Instance.BuildImageUrl(Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>(), imageId));
        }

        public static System.Uri BuildImageUri(System.Guid imageId, bool original)
        {
            return new System.Uri(ImageUriFactoryHelper.Instance.BuildImageUrl(Xamarin.Forms.DependencyService.Get<ICloudServerProviderFacade>(), imageId, original));
        }
    }
}
