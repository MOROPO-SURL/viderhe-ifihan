using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    [Route("api/[area]/[controller]")]
    [Area("business")]
    [SAPRESSC.Core.Web.Security.Filters.ChangeUserPasswordRequiredAction]
    [SAPRESSC.Core.Web.Security.Filters.CatchChangeUserPasswordRequiredException]
    public class PlacardsController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Persistence.Entities.Placard, System.Guid, PlacardInputModel, PlacardDisplayModel>
    {
        private readonly IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository;
        private readonly IEntityRepository<Persistence.Entities.Template, System.Guid> templateRepository;

        public PlacardsController(IEntityRepository<Persistence.Entities.Template, System.Guid> templateRepository, IEntityRepository<Persistence.Entities.Account, System.Guid> accountRepository, IEntityRepository<Persistence.Entities.Placard, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PlacardsController> localizer, ILogger<PlacardsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.templateRepository = templateRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Placard, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            return e => e.Account.Id == accountId;
        }

        protected override void PreCreate(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));
            entity.Template = templateRepository.Get(inputModel.TemplateId);
        }

        protected override void PreEdit(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Persistence.Entities.Placard entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }
    }
}
