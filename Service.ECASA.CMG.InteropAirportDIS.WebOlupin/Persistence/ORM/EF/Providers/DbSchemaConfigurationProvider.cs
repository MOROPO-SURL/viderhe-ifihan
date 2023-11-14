namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Providers
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
                    new Configurators.CarrierEntityTypeConfigurator(),
                    new Configurators.CategoryEntityTypeConfigurator(),
                    new Configurators.KindEntityTypeConfigurator(),
                    new Configurators.StatusEntityTypeConfigurator(),
                    new Configurators.TerminalEntityTypeConfigurator(),
                    new Configurators.MunicipalityLocationEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}
