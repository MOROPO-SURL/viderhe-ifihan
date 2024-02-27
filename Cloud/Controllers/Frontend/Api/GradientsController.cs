using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    public class GradientsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Gradient, System.Guid, GradientInputModel, GradientDisplayModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;
        private readonly IBridgeRepository<AccountGradientBridge, Account, System.Guid, Gradient, System.Guid> accountGradientBridgeRepository;

        public GradientsController(IBridgeRepository<AccountGradientBridge, Account, System.Guid, Gradient, System.Guid> accountGradientBridgeRepository, IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Gradient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<GradientsController> localizer, ILogger<GradientsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.accountGradientBridgeRepository = accountGradientBridgeRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Gradient, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.AccountBridges.Any(b => b.ProwId == accountId);
        }

        protected override void PreCreate(Gradient entity, GradientInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            account.GradientBridges.Add(new AccountGradientBridge
            {
                ProwId = account.Id,
                Prow = account,
                SternId = entity.Id,
                Stern = entity
            });

            accountRepository.Update(account, User.Identity.Name, false);
        }

        protected override void PreEdit(Gradient entity, GradientInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            if (!accountGradientBridgeRepository.GetAll().Any(bridge => bridge.ProwId == account.Id && bridge.SternId == entity.Id)) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Gradient entity)
        {
            base.PreDelete(entity);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            if (!accountGradientBridgeRepository.GetAll().Any(bridge => bridge.ProwId == account.Id && bridge.SternId == entity.Id)) throw new System.InvalidOperationException();
        }
    }
}
