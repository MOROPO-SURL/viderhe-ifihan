using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_ASSOCIATED)]
    [Route("api/[area]/[controller]")]
    [Area("business")]
    [SAPRESSC.Core.Web.Security.Filters.ChangeUserPasswordRequiredAction]
    [SAPRESSC.Core.Web.Security.Filters.CatchChangeUserPasswordRequiredException]
    public class FramesController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementFilteredController<Persistence.Entities.Frame, long, FrameInputModel, FrameDisplayModel, FrameFilterModel>
    {
        private readonly IEntityRepository<Persistence.Entities.Screenplay, System.Guid> screenplayRepository;
        private readonly IEntityRepository<Persistence.Entities.Placard, System.Guid> placardRepository;

        public FramesController(IEntityRepository<Persistence.Entities.Placard, System.Guid> placardRepository, IEntityRepository<Persistence.Entities.Screenplay, System.Guid> screenplayRepository, IEntityRepository<Persistence.Entities.Frame, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<FramesController> localizer, ILogger<FramesController> logger) : base(repository, localizer, logger)
        {
            this.screenplayRepository = screenplayRepository;
            this.placardRepository = placardRepository;
        }

        public override ActionResult<FrameDisplayModel[]> Get()
        {
            return NotFound();
        }

        public override ActionResult<FrameDisplayModel> Get(long key)
        {
            return NotFound();
        }

        public override ActionResult<SAPRESSC.Core.Common.Models.PaginationModel<FrameDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return NotFound();
        }

        public override ActionResult Edit([FromBody] FrameInputModel inputModel)
        {
            return NotFound();
        }

        [HttpPut("orderup/{key}")]
        public ActionResult OrderUp(long key)
        {
            try
            {
                var targetEntity = Repository.Get(key);

                var upEntity = targetEntity.Screenplay.Frames.Where(e => e.Priority < targetEntity.Priority).OrderByDescending(e => e.Priority).First();

                var targetPriority = upEntity.Priority;

                upEntity.Priority = targetEntity.Priority;

                targetEntity.Priority = targetPriority;

                Repository.Update(upEntity, User.Identity.Name, false);
                Repository.Update(targetEntity, User.Identity.Name);
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }

            return Ok();
        }

        [HttpPut("orderdown/{key}")]
        public ActionResult OrderDown(long key)
        {
            try
            {
                var targetEntity = Repository.Get(key);

                var downEntity = targetEntity.Screenplay.Frames.Where(e => e.Priority > targetEntity.Priority).OrderByDescending(e => e.Priority).Last();

                var targetPriority = downEntity.Priority;

                downEntity.Priority = targetEntity.Priority;

                targetEntity.Priority = targetPriority;

                Repository.Update(downEntity, User.Identity.Name, false);
                Repository.Update(targetEntity, User.Identity.Name);
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }

            return Ok();
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Frame, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            return entity => entity.Screenplay.Account.Id == accountId && entity.Placard.Template.Enabled;
        }

        protected override void PreCreate(Persistence.Entities.Frame entity, FrameInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            entity.Screenplay = screenplayRepository.FindOneBy(e => e.Id == inputModel.ScreenplayId && e.Account.Id == accountId) ?? throw new System.InvalidOperationException();

            entity.Placard = placardRepository.FindOneBy(e => e.Id == inputModel.PlacardId && e.Account.Id == accountId) ?? throw new System.InvalidOperationException();

            var screenplayLastFrame = entity.Screenplay.Frames.OrderBy(e => e.Priority).LastOrDefault();

            entity.Priority = screenplayLastFrame?.Priority + 1 ?? 1;
        }

        protected override void PreDelete(Persistence.Entities.Frame entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Placard.Account.Id != accountId) throw new System.InvalidOperationException();
        }
    }
}
