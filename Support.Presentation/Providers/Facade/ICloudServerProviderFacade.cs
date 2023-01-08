namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Providers.Facade
{
    public interface ICloudServerProviderFacade
    {
        string Host { get; }

        bool UseSSL { get; }
    }
}
