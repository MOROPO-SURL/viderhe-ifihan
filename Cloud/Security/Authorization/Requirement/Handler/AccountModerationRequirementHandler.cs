using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Cloud.Persistence.ORM.EF;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Security.Authorization.Requirement.Handler
{
    public class AccountModerationRequirementHandler : Microsoft.AspNetCore.Authorization.AuthorizationHandler<AccountModerationRequirement>
    {
        private readonly ApplicationDbContext dbContext;

        public AccountModerationRequirementHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override System.Threading.Tasks.Task HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext context, AccountModerationRequirement requirement)
        {
            var account = dbContext.Accounts
                .Include(entity => entity.ModeratorBridges).ThenInclude(bridge => bridge.Stern)
                .Where(e => e.Enabled && e.ModeratorBridges.Any(n => n.Stern.UserId == context.User.Identity.Name)).FirstOrDefault();

            if (account != null && Helpers.Integrity.AccountIntegrityHelper.IsCorrectlySigned(account))
            {
                context.Succeed(requirement);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
