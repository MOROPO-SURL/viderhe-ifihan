using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Security.Authorization.Requirement.Handler
{
    public class AccountModerationRequirementHandler : Microsoft.AspNetCore.Authorization.AuthorizationHandler<AccountModerationRequirement>
    {
        private readonly Persistence.EF.ApplicationDbContext dbContext;

        public AccountModerationRequirementHandler(Persistence.EF.ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override System.Threading.Tasks.Task HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext context, AccountModerationRequirement requirement)
        {
            var isModerator = dbContext.Accounts.Any(e => e.Enabled && Helpers.Integrity.AccountIntegrityHelper.IsCorrectlySigned(e) && e.ModeratorBridges.Any(n => n.Moderator.UserId == context.User.Identity.Name));

            if (isModerator)
            {
                context.Succeed(requirement);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
