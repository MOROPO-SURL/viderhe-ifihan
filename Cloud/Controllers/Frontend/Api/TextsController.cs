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
    public class TextsController : MOROPO.SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Text, System.Guid, TextInputModel, TextDisplayModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public TextsController(IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Text, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TextsController> localizer, ILogger<TextsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Text, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            return e => e.AccountBridges.Any(b => b.AccountId == accountId);
        }

        protected override void PreCreate(Text entity, TextInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            account.TextBridges.Add(new AccountTextBridge
            {
                AccountId = account.Id,
                Account = account,
                TextId = entity.Id,
                Text = entity
            });

            accountRepository.Update(account, User.Identity.Name, false);
        }

        protected override void PreEdit(Text entity, TextInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (!account.TextBridges.Any(bridge => bridge.TextId == entity.Id)) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Text entity)
        {
            base.PreDelete(entity);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (!account.TextBridges.Any(bridge => bridge.TextId == entity.Id)) throw new System.InvalidOperationException();
        }
    }
}
