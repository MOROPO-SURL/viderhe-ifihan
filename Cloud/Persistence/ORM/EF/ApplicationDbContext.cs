using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Essential.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Persistence.ORM.EF
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Contract.IModulePersistenceDbContext,
        Framework.Guama.Security.Essential.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Framework.Guama.Identity.Persistence.ORM.EF.Context.IPersistenceDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

#if DEBUG
        public override bool TraceChanges => false;
#endif

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleBridge> UserRoleBridges { get; set; }

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

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTagBridge> PlayerTagBridges { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public DbSet<Gradient> Gradients { get; set; }
        public DbSet<Screenplay> ScreenPlays { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Placard> Placards { get; set; }
        public DbSet<PlacardImageBridge> PlacardImageBridges { get; set; }
        public DbSet<PlacardVideoBridge> PlacardVideoBridges { get; set; }
        public DbSet<PlacardSoundBridge> PlacardSoundBridges { get; set; }
        public DbSet<PlacardGradientBridge> PlacardGradientBridges { get; set; }
        public DbSet<PlacardTagBridge> PlacardTagBridges { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<Overlay> Overlays { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<AccountModeratorBridge> AccountModeratorBridges { get; set; }
        public DbSet<AccountImageBridge> AccountImageBridges { get; set; }
        public DbSet<AccountVideoBridge> AccountVideoBridges { get; set; }
        public DbSet<AccountExtensionBridge> AccountExtensionBridges { get; set; }
        public DbSet<AccountSoundBridge> AccountSoundBridges { get; set; }
        public DbSet<AccountGradientBridge> AccountGradientBridges { get; set; }
        public DbSet<AccountTextBridge> AccountTextBridges { get; set; }
        public DbSet<ScheduledRelaunch> ScheduledRelaunches { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
