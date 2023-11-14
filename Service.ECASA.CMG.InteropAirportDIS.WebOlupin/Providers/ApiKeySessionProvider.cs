using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Providers
{
    public class ApiKeySessionProvider : AspNetCore.Authentication.ApiKey.IApiKeyProvider
    {
        private readonly IEntityRepository<InterFIDS.Persistence.Entities.ApiKey, System.Guid> apiKeyRepository;
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor;

        public ApiKeySessionProvider(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IEntityRepository<InterFIDS.Persistence.Entities.ApiKey, System.Guid> apiKeyRepository)
        {
            this.apiKeyRepository = apiKeyRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public System.Threading.Tasks.Task<AspNetCore.Authentication.ApiKey.IApiKey> ProvideAsync(string key)
        {
            var apiKey = apiKeyRepository.FindOneBy(entity => entity.Enabled && entity.Token == key);

            if (apiKey == null || !apiKey.Enabled) return System.Threading.Tasks.Task.FromResult<AspNetCore.Authentication.ApiKey.IApiKey>(null);

            if (!string.IsNullOrEmpty(apiKey.Host) && httpContextAccessor.HttpContext.Request.Host.Host != apiKey.Host) return System.Threading.Tasks.Task.FromResult<AspNetCore.Authentication.ApiKey.IApiKey>(null);

            var apiKeySession = new Models.Api.SessionApiModel(apiKey);

            httpContextAccessor.HttpContext.Features.Set<AspNetCore.Authentication.ApiKey.IApiKey>(apiKeySession);

            return System.Threading.Tasks.Task.FromResult<AspNetCore.Authentication.ApiKey.IApiKey>(apiKeySession);
        }
    }
}
