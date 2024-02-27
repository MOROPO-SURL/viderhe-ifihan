using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Managers
{
    public class IdentityManager : Framework.Guama.Security.Essential.Presentation.Web.Common.Managers.IdentityManager
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public IdentityManager(IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Framework.Guama.Security.Essential.Persistence.Entities.User, string> userRepository, ILogger<IdentityManager> logger) : base(userRepository, logger)
        {
            this.accountRepository = accountRepository;
        }

        public override void ConfigureClaims(Framework.Guama.Security.Essential.Persistence.Entities.User user, System.Collections.Generic.List<System.Security.Claims.Claim> claims)
        {
            base.ConfigureClaims(user, claims);

            var account = accountRepository.FindOneBy(entity => entity.ModeratorBridges.Any(b => b.Stern.UserId == user.Id));

            if (account != null)
            {
                claims.Add(new System.Security.Claims.Claim(Claims.ACCOUNT_CLAIM, account.Id.ToString()));
            }
        }
    }
}
