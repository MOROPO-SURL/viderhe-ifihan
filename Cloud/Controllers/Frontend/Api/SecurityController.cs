using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Providers.Facade;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Options;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly Microsoft.Extensions.Options.IOptions<JwtOptions> jwtOptions;
        private readonly IIdentityProviderFacade identityProvider;
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public SecurityController(IEntityRepository<Account, System.Guid> accountRepository, IIdentityProviderFacade identityProvider, Microsoft.Extensions.Options.IOptions<JwtOptions> jwtOptions, Microsoft.Extensions.Localization.IStringLocalizer<SecurityController> localizer, ILogger<SecurityController> logger) : base(localizer, logger)
        {
            this.jwtOptions = jwtOptions;
            this.identityProvider = identityProvider;
            this.accountRepository = accountRepository;
        }

        [HttpPost("[action]")]
        public ActionResult<AuthenticatedSessionModel> Authenticate([FromBody] AuthenticationIntentModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = identityProvider.ProvideIdentity(inputModel.User, inputModel.Password, Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);

                if (userIdentity != null)
                {
                    var account = accountRepository.FindOneBy(entity => entity.Enabled && entity.ModeratorBridges.Any(bridge => bridge.Stern.UserId == userIdentity.Name));

                    if (userIdentity.HasClaim(match => match.Type.Equals(Framework.Guama.Core.Presentation.Web.Security.Constants.ClaimTypes.AccountDisabled) && match.Value.Equals(true.ToString())) || account == null)
                    {
                        return Forbid(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
                    }

                    userIdentity.AddClaim(new System.Security.Claims.Claim(Policies.ACCOUNT_VALIDATED_MODERATION, account.Id.ToString()));

                    var moderator = account.ModeratorBridges.First(b => b.Stern.UserId == userIdentity.Name).Stern;

                    return GenerateToken(userIdentity, moderator);
                }

                return Unauthorized();
            }

            return BadRequest();
        }

        [HttpPost("[action]")]
        [Microsoft.AspNetCore.Authorization.Authorize(Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
        public ActionResult ChangePassword([FromBody] UserPasswordChangeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var identityManager = identityProvider as Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IIdentityManagerFacade;

                if (identityManager.TryModifyPassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        #region Token Utility Methods

        private ActionResult GenerateToken(System.Security.Claims.ClaimsIdentity userClaims, Moderator moderator)
        {
            var token = GenerateJwtToken(userClaims);

            var model = new ModeratorDisplayModel();

            model.Import(moderator);

            return Json(new AuthenticatedSessionModel
            {
                Token = token,
                Type = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme,
                ExpiresInSecond = jwtOptions.Value.ExpiresInSecond,
                Moderator = model
            });
        }

        private string GenerateJwtToken(System.Security.Claims.ClaimsIdentity userIdentity)
        {
            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions.Value.Key));
            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
            var expires = System.DateTime.Now.AddSeconds(jwtOptions.Value.ExpiresInSecond);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                jwtOptions.Value.Issuer,
                jwtOptions.Value.Issuer,
                userIdentity.Claims,
                expires: expires,
                signingCredentials: creds
            );

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
