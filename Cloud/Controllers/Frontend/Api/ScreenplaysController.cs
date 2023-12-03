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
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class ScreenplaysController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Screenplay, System.Guid, ScreenplayInputModel, ScreenplayDisplayModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;
        private readonly IEntityRepository<Player, string> playerRepository;

        public ScreenplaysController(IEntityRepository<Player, string> playerRepository, IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Screenplay, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScreenplaysController> localizer, ILogger<ScreenplaysController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.playerRepository = playerRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Screenplay, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.Account.Id == accountId;
        }

        public override ActionResult<ScreenplayDisplayModel[]> Get()
        {
            return Ok(Repository.GetAll().Where(GetGlobalSelector()).OrderBy(entity => entity.Title).ToArray().Select(entity => EntityToDisplayModel(entity)).ToArray());
        }

        protected override void PreCreate(Screenplay entity, ScreenplayInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));
        }

        protected override void PreEdit(Screenplay entity, ScreenplayInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Screenplay entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override void PostDelete(Screenplay entity)
        {
            base.PostDelete(entity);

            var relatedPlayers = playerRepository.FindBy(item => item.ScreenplayId == entity.Id).ToArray();

            if (relatedPlayers.Length <= 0) return;

            var relatedPlayerQueue = new System.Collections.Generic.Queue<Player>(relatedPlayers);

            while (relatedPlayerQueue.Count > 1)
            {
                var player = relatedPlayerQueue.Dequeue();

                player.Screenplay = null;
                player.ScreenplayId = null;

                playerRepository.Update(player, User.Identity.Name, false);
            }

            var lastPlayer = relatedPlayerQueue.Dequeue();

            lastPlayer.Screenplay = null;
            lastPlayer.ScreenplayId = null;

            playerRepository.Update(lastPlayer, User.Identity.Name, true);
        }
    }
}
