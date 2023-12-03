using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
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
    public class TagsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementFilteredController<Tag, System.Guid, TagInputModel, TagDisplayModel, TagFilterModel>
    {
        private readonly IEntityRepository<Account, System.Guid> accountRepository;

        public TagsController(IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Tag, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TagsController> localizer, ILogger<TagsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Tag, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.Account.Id == accountId;
        }

        public override ActionResult<TagDisplayModel[]> Get()
        {
            return NotFound();
        }

        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<TagDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return NotFound();
        }

        protected override void PreCreate(Tag entity, TagInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));
        }

        protected override void PreEdit(Tag entity, TagInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override void PreDelete(Tag entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }
    }
}
