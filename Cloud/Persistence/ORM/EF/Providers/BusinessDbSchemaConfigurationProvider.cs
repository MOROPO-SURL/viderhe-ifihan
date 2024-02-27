namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Providers
{
    public sealed class BusinessDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public string DefaultPersistenceSchema => null;

        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.IEntityTypeConfigurator> EntityTypeConfigurators => new System.Collections.Generic.List<Framework.Guama.Core.Persistence.ORM.EF.Configurators.IEntityTypeConfigurator>
        {
            new Configurators.TagEntityTypeConfigurator(),
            new Configurators.AccountImageBridgeEntityTypeConfigurator(),
            new Configurators.AccountExtensionBridgeEntityTypeConfigurator(),
            new Configurators.AccountModeratorBridgeEntityTypeConfigurator(),
            new Configurators.AccountVideoBridgeEntityTypeConfigurator(),
            new Configurators.FrameEntityTypeConfigurator(),
            new Configurators.PlayerEntityTypeConfigurator(),
            new Configurators.PlayerTagBridgeEntityTypeConfigurator(),
            new Configurators.ModeratorEntityTypeConfigurator(),
            new Configurators.ScheduledRelaunchEntityTypeConfigurator(),
            new Configurators.PlacardImageBridgeEntityTypeConfigurator(),
            new Configurators.PlacardVideoBridgeEntityTypeConfigurator(),
            new Configurators.AccountSoundBridgeEntityTypeConfigurator(),
            new Configurators.AccountGradientBridgeEntityTypeConfigurator(),
            new Configurators.AccountTextBridgeEntityTypeConfigurator(),
            new Configurators.PlacardSoundBridgeEntityTypeConfigurator(),
            new Configurators.PlacardGradientBridgeEntityTypeConfigurator(),
            new Configurators.PlacardTagBridgeEntityTypeConfigurator()
        };
    }
}
