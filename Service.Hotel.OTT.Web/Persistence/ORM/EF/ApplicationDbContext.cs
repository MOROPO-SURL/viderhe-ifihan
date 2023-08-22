using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities.Contract;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Framework.Guama.Identity.Persistence.ORM.EF.Context.IPersistenceDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        //#if DEBUG
        //        public override bool TraceChanges => false;
        //#endif

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }

        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StateLocation> StateLocations { get; set; }
        public DbSet<MunicipalityLocation> MunicipalityLocations { get; set; }
        public DbSet<LocalityLocation> LocalityLocations { get; set; }

        public DbSet<PersonIdentity> PersonIdentities { get; set; }
        public DbSet<OrganizationPostalContactItemBridge> OrganizationPostalContactItemBridges { get; set; }
        public DbSet<OrganizationPhoneContactItemBridge> OrganizationPhoneContactItemBridges { get; set; }
        public DbSet<OrganizationEmailContactItemBridge> OrganizationEmailContactItemBridges { get; set; }
        public DbSet<PersonWebSiteContactItemBridge> PersonWebSiteContactItemBridges { get; set; }
        public DbSet<PersonSocialContactItemBridge> PersonSocialContactItemBridges { get; set; }
        public DbSet<PersonPostalContactItemBridge> PersonPostalContactItemBridges { get; set; }
        public DbSet<PersonPhoneContactItemBridge> PersonPhoneContactItemBridges { get; set; }
        public DbSet<PersonEmailContactItemBridge> PersonEmailContactItemBridges { get; set; }
        public DbSet<PostalContactItem> PostalContactItems { get; set; }
        public DbSet<WebSiteContactItem> WebSiteContactItems { get; set; }
        public DbSet<SocialContactItem> SocialContactItems { get; set; }
        public DbSet<PhoneContactItem> PhoneContactItems { get; set; }
        public DbSet<EmailContactItem> EmailContactItems { get; set; }
        public DbSet<OrganizationPersonMembershipBridge> OrganizationPersonMembershipBridges { get; set; }
        public DbSet<OrganizationIdentity> OrganizationIdentities { get; set; }
        public DbSet<OrganizationSocialContactItemBridge> OrganizationSocialContactItemBridges { get; set; }
        public DbSet<OrganizationWebSiteContactItemBridge> OrganizationWebSiteContactItemBridges { get; set; }

        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<ApiKeyPermissionBridge> ApiKeyPermissionBridges { get; set; }
        public DbSet<AVCategory> AVCategories { get; set; }
        public DbSet<AVGenre> AVGenres { get; set; }
        public DbSet<AVParticipation> AVParticipations { get; set; }
        public DbSet<AVProducerHouse> AVProducerHouses { get; set; }
        public DbSet<AVProduction> AVProductions { get; set; }
        public DbSet<AVProductionAVGenreBridge> AVProductionAVGenreBridges { get; set; }
        public DbSet<AVProductionAVProducerHouseBridge> AVProductionAVProducerHousesBridges { get; set; }
        public DbSet<AVProductionCountryBridge> AVProductionCountryBridges { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<CommonArea> CommonAreas { get; set; }
        public DbSet<CustomService> CustomServices { get; set; }
        public DbSet<CustomServiceLanguageBridge> CustomServiceLanguageBridges { get; set; }
        public DbSet<CustomServiceZoneBridge> CustomServiceZoneBridges { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileChannelBridge> ProfileChannelBridges { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SwimingPool> SwimingPools { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneScheduleBridge> ZoneScheduleBridges { get; set; }
        public DbSet<ZoneImageBridge> ZoneImageBridges { get; set; }
    }
}
