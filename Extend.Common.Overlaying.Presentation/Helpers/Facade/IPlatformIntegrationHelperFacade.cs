namespace SmartSolucionesCuba.Viderhe.Extend.Common.Overlaying.Presentation.Helpers.Facade
{
    public interface IPlatformIntegrationHelperFacade
    {
        System.Threading.Tasks.Task LaunchApplication(string discriminator);

        System.Threading.Tasks.Task OpenDocument(string path);

        System.Threading.Tasks.Task OpenDocument(System.IO.Stream documentStream);
    }
}
