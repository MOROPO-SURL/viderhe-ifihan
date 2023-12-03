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
    public class TextsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Text, System.Guid, TextInputModel, TextDisplayModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public TextsController(IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Text, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TextsController> localizer, ILogger<TextsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Text, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.AccountBridges.Any(b => b.ProwId == accountId);
        }

        protected override void PreCreate(Text entity, TextInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            account.TextBridges.Add(new AccountTextBridge
            {
                ProwId = account.Id,
                Prow = account,
                SternId = entity.Id,
                Stern = entity
            });

            accountRepository.Update(account, User.Identity.Name, false);
        }

        protected override void PreEdit(Text entity, TextInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            if (!account.TextBridges.Any(bridge => bridge.SternId == entity.Id)) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Text entity)
        {
            base.PreDelete(entity);

            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));

            if (!account.TextBridges.Any(bridge => bridge.SternId == entity.Id)) throw new System.InvalidOperationException();
        }
    }
}
