using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Models.Api
{
    public class SessionApiModel : AspNetCore.Authentication.ApiKey.IApiKey
    {
        public SessionApiModel(OTT.Persistence.Entities.ApiKey entity)
        {
            ApiKey = entity;

            var claims = new System.Collections.Generic.List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.AuthenticationMethod, AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)
            };

            if (entity.HasFullAccess)
            {
                claims.Add(new System.Security.Claims.Claim(Framework.Guama.Core.Presentation.Web.Security.Constants.ClaimTypes.AccountWithFullAccess, true.ToString()));
            }

            foreach (var bridge in entity.RoleBridges)
            {
                claims.AddRange(entity.RoleBridges.Select(item => new System.Security.Claims.Claim(System.Security.Claims.ClaimsIdentity.DefaultRoleClaimType, item.Stern.Id.ToString())).ToArray());
            }

            Claims = claims;
        }

        public string Key => ApiKey.Token;

        public string OwnerName => ApiKey.Id.ToString();

        public System.Collections.Generic.IReadOnlyCollection<System.Security.Claims.Claim> Claims { get; private set; }

        public OTT.Persistence.Entities.ApiKey ApiKey { get; private set; }
    }
}
