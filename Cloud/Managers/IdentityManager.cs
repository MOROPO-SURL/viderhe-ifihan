using Microsoft.Extensions.Logging;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Managers
{
    public class IdentityManager : SAPRESSC.Core.Web.SecurityLocal.Managers.IdentityManager
    {
        private readonly SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository;

        public IdentityManager(SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository, SAPRESSC.Core.Persistence.Repositories.IEntityRepository<SAPRESSC.Core.Security.Persistence.Entities.User, string> userRepository, ILogger<IdentityManager> logger) : base(userRepository, logger)
        {
            this.accountRepository = accountRepository;
        }

        public override void ConfigureClaims(SAPRESSC.Core.Security.Persistence.Entities.User user, System.Collections.Generic.List<System.Security.Claims.Claim> claims)
        {
            base.ConfigureClaims(user, claims);

            var account = accountRepository.FindOneBy(entity => entity.ModeratorBridges.Any(b => b.Moderator.UserId == user.Id));

            if (account != null)
            {
                claims.Add(new System.Security.Claims.Claim(Security.Authorization.Claims.ACCOUNT_CLAIM, account.Id.ToString()));
            }
        }
    }
}
