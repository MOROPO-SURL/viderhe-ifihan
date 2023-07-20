using Microsoft.AspNetCore.Mvc;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class ComplementationsController : Controller
    {
        private readonly MOROPO.SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Placard, System.Guid> repository;

        public ComplementationsController(MOROPO.SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Placard, System.Guid> repository)
        {
            this.repository = repository;
        }

        [HttpPut]
        public virtual ActionResult Edit([FromBody] Cloud.Api.Common.Models.ComplementationInputModel model)
        {
            try
            {
                var entity = repository.Get(model.PlacardId);

                entity.ComplementationKind = model.ComplementationKind;
                entity.SerializedComplementation = model.SerializedComplementation;

                repository.Update(entity, User.Identity.Name);

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NoContent();
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }
    }
}
