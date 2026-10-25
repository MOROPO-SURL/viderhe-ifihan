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
    public class FramesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementFilteredController<Frame, long, FrameInputModel, FrameDisplayModel, FrameFilterModel>
    {
        private readonly IEntityRepository<Screenplay, System.Guid> screenplayRepository;
        private readonly IEntityRepository<Placard, System.Guid> placardRepository;

        public FramesController(IEntityRepository<Placard, System.Guid> placardRepository, IEntityRepository<Screenplay, System.Guid> screenplayRepository, IEntityRepository<Frame, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<FramesController> localizer, ILogger<FramesController> logger) : base(repository, localizer, logger)
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

        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<FrameDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return NotFound();
        }

        public override ActionResult Edit([FromBody] FrameInputModel inputModel)
        {
            return NotFound();
        }

        // TODO Make accesible for VIDERHE Player
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public override ActionResult<FrameDisplayModel[]> GetFiltered([FromBody] FrameFilterModel filterModel)
        {
            return base.GetFiltered(filterModel);
        }

        [HttpPut("{key}/order/{priority}")]
        public ActionResult Order(long key, int priority)
        {
            try
            {
                var target = Repository.Get(key);

                System.Collections.Generic.Queue<Frame> implicates;

                if (priority < target.Priority)
                {
                    implicates = new System.Collections.Generic.Queue<Frame>(target.Screenplay.Frames.OrderByDescending(e => e.Priority).Where(e => e.Priority >= priority && e.Priority < target.Priority));
                }
                else
                {
                    implicates = new System.Collections.Generic.Queue<Frame>(target.Screenplay.Frames.OrderByDescending(e => e.Priority).Where(e => e.Priority <= priority && e.Priority > target.Priority));
                }

                while (implicates.Count > 0)
                {
                    var current = implicates.Dequeue();

                    if (priority < target.Priority)
                    {
                        current.Priority++;
                    }
                    else
                    {
                        current.Priority--;
                    }

                    Repository.Update(current, User.Identity.Name, false);
                }

                target.Priority = priority;

                Repository.Update(target, User.Identity.Name, true);

                ReOrderFrames(target.ScreenplayId);
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

        protected override System.Linq.Expressions.Expression<System.Func<Frame, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return entity => entity.Screenplay.Account.Id == accountId && entity.Placard.Template.Enabled;
        }

        protected override void PreCreate(Frame entity, FrameInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            entity.Screenplay = screenplayRepository.FindOneBy(e => e.Id == inputModel.ScreenplayId && e.Account.Id == accountId) ?? throw new System.InvalidOperationException();

            entity.Placard = placardRepository.FindOneBy(e => e.Id == inputModel.PlacardId && e.Account.Id == accountId) ?? throw new System.InvalidOperationException();

            var screenplayLastFrame = entity.Screenplay.Frames.OrderBy(e => e.Priority).LastOrDefault();

            entity.Priority = screenplayLastFrame?.Priority + 1 ?? 1;
        }

        protected override void PreDelete(Frame entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Placard.Account.Id != accountId) throw new System.InvalidOperationException();
        }

        protected override void PostDelete(Frame entity)
        {
            base.PostDelete(entity);

            ReOrderFrames(entity.ScreenplayId);
        }

        private void ReOrderFrames(System.Guid screenplayId)
        {
            var entities = Repository.FindBy(_entity => _entity.ScreenplayId == screenplayId).OrderBy(_entity => _entity.Priority).ToList();

            if (entities.Count <= 0) return;

            var index = 0;

            while (entities.Count > 1)
            {
                var next = entities.First();

                next.Priority = ++index;

                Repository.Update(next, "system", false);

                entities.RemoveAt(0);
            }

            var last = entities.First();

            last.Priority = index + 1;

            Repository.Update(last, "system");
        }
    }
}
