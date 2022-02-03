namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.EF.Providers
{
    public sealed class BusinessDbSchemaConfigurationProvider : SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public string DefaultPersistenceSchema => null;

        public System.Collections.Generic.ICollection<SAPRESSC.Core.Persistence.EF.Configurators.IEntityTypeConfigurator> EntityTypeConfigurators => new System.Collections.Generic.List<SAPRESSC.Core.Persistence.EF.Configurators.IEntityTypeConfigurator>
        {
            new Configurators.AccountImageBridgeEntityTypeConfigurator(),
            new Configurators.AccountExtensionBridgeEntityTypeConfigurator(),
            new Configurators.AccountModeratorBridgeEntityTypeConfigurator(),
            new Configurators.AccountVideoBridgeEntityTypeConfigurator(),
            new Configurators.FrameEntityTypeConfigurator(),
            new Configurators.PlayerEntityTypeConfigurator(),
            new Configurators.ModeratorEntityTypeConfigurator(),
            new Configurators.ScheduledRelaunchEntityTypeConfigurator()
        };
    }
}
