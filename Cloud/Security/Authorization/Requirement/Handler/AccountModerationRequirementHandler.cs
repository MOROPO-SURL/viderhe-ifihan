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
            var challange = dbContext.Accounts.Any(e => e.Enabled && Helpers.Integrity.AccountIntegrityHelper.IsCorrectlySigned(e) && e.ModeratorBridges.Any(n => n.Stern.UserId == context.User.Identity.Name));

            if (challange)
            {
                context.Succeed(requirement);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
