namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Providers.Facade
{
    public interface IPlacardContextDependenciesProvider
    {
        Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext);

        Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext);

        Models.Context.GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext);

        Models.Context.SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt);
    }
}
