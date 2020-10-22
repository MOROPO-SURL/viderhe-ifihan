using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Videre.Cloud.Api.Common.Models;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    [Route("api/[area]/[controller]")]
    [Area("business")]
    public class PlayersController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Persistence.Entities.Player, string, PlayerInputModel, PlayerDisplayModel>
    {
        private readonly SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository;

        public PlayersController(SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository, SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Player, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<PlayersController> localizer, ILogger<PlayersController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult Account()
        {
            var protectedPlayerId = Request.Headers[Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY];

            var playerId = Helpers.Security.PlayerSecurityHelper.UnprotectPlayerId(protectedPlayerId);

            try
            {
                var player = Repository.Get(playerId);

                var model = new AccountDisplayModel();

                model.Import(player.Account);

                Response.Headers.Add(Request.Headers.First(header => header.Key == Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY));

                return Ok(model);
            }
            catch
            {
                return Forbid(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
            }
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult ScreenplayPlacards()
        {
            try
            {
                var accountId = Request.Headers[Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.ACCOUNT_ID_HEADER_KEY];

                var protectedPlayerId = Request.Headers[Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY];

                var playerId = Helpers.Security.PlayerSecurityHelper.UnprotectPlayerId(protectedPlayerId);

                var player = Repository.Get(playerId);

                if (player.Account.Id.ToString() != accountId.ToString())
                {
                    return Forbid(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
                }

                Response.Headers.Add(Request.Headers.First(header => header.Key == Cloud.Api.Common.Providers.Constant.SecurityConstantProvider.PROTECTED_PLAYER_ID_HEADER_KEY));

                return Ok(player.Screenplay.Frames.OrderBy(e => e.Priority).Select((Persistence.Entities.Frame entity) =>
                {
                    var model = new PlacardDisplayModel();

                    model.Import(entity.Placard);

                    return model;
                }).ToArray());
            }
            catch
            {
                return NoContent();
            }
        }

        public override IActionResult Create([FromBody] PlayerInputModel inputModel)
        {
            var account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (account.MaxPlayerCount <= Repository.Count())
            {
                return Forbid(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
            }

            return base.Create(inputModel);
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Player, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            return e => e.Account.Id == accountId;
        }

        protected override void PreCreate(Persistence.Entities.Player entity, PlayerInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));

            if (inputModel.ScreenplayId != System.Guid.Empty)
            {
                entity.Screenplay = entity.Account.Screenplays.First(e => e.Id == inputModel.ScreenplayId);
            }

            entity.Signature = Helpers.Integrity.PlayerIntegrityHelper.GetSignature(entity);
        }

        protected override void PreEdit(Persistence.Entities.Player entity, PlayerInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();

            if (entity.Screenplay == null || entity.Screenplay.Id != inputModel.ScreenplayId)
            {
                if (inputModel.ScreenplayId == System.Guid.Empty)
                {
                    entity.Screenplay = null;
                }
                else
                {
                    var account = accountRepository.Get(accountId);

                    entity.Screenplay = account.Screenplays.First(e => e.Id == inputModel.ScreenplayId);
                }
            }

            entity.Signature = Helpers.Integrity.PlayerIntegrityHelper.GetSignature(entity);
        }

        protected override void PreDelete(Persistence.Entities.Player entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override PlayerDisplayModel EntityToDisplayModel(Persistence.Entities.Player entity)
        {
            var model = base.EntityToDisplayModel(entity);

            var playerSignalRContext = Providers.PlayerContextsSignalRModelProvider.Instance.Contexts.FirstOrDefault(m => m.PlayerId == entity.Id);

            if (playerSignalRContext != null)
            {
                model.IsConnected = playerSignalRContext != null;
                model.AudioEnabled = playerSignalRContext.AudioEnabled;
                model.AudioLevel = playerSignalRContext.AudioLevel;
            }

            return model;
        }
    }
}
