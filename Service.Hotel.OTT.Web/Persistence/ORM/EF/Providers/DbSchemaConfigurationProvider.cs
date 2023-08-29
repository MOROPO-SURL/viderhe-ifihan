namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Providers
{
    public class DbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Framework.Guama.Core.Persistence.ORM.EF.Configurators.IEntityTypeConfigurator>
                {
                    new Configurators.ApiKeyRoleBridgeEntityTypeConfigurator(),
                    new Configurators.AVProductionAVGenreBridgeEntityTypeConfigurator(),
                    new Configurators.AVProductionAVProducerHouseBridgeEntityTypeConfigurator(),
                    new Configurators.AVProductionCountryBridgeEntityTypeConfigurator(),
                    new Configurators.CustomServiceLanguageBridgeEntityTypeConfigurator(),
                    new Configurators.CustomServiceZoneBridgeEntityTypeConfigurator(),
                    new Configurators.ProfileChannelBridgeEntityTypeConfigurator(),
                    new Configurators.ZoneImageBridgeEntityTypeConfigurator(),
                    new Configurators.ZoneScheduleBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}
