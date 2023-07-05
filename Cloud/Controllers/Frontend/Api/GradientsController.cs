using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    public class GradientsController : MOROPO.SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Gradient, System.Guid, GradientInputModel, GradientDisplayModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public GradientsController(IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Gradient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<GradientsController> localizer, ILogger<GradientsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Gradient, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            return e => e.AccountBridges.Any(b => b.AccountId == accountId);
        }

        protected override void PreCreate(Gradient entity, GradientInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            account.GradientBridges.Add(new AccountGradientBridge
            {
                AccountId = account.Id,
                Account = account,
                GradientId = entity.Id,
                Gradient = entity
            });

            accountRepository.Update(account, User.Identity.Name, false);
        }

        protected override void PreEdit(Gradient entity, GradientInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (!account.GradientBridges.Any(bridge => bridge.GradientId == entity.Id)) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Gradient entity)
        {
            base.PreDelete(entity);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (!account.GradientBridges.Any(bridge => bridge.GradientId == entity.Id)) throw new System.InvalidOperationException();
        }
    }
}
