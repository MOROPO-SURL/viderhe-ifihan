using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Providers.Facade
{
    public interface IPlacardContextDependenciesProvider
    {
        ImageContextModel[] GetImages(System.Guid templateId, string serializedContext);

        VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext);

        GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext);

        SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt);
    }
}
