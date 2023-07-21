using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

                if (entity.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Video)
                {
                    UpdateVideoDependencies(entity, model);
                }
                else if (entity.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Sound)
                {
                    UpdateSoundDependencies(entity, model);
                }

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

        private void UpdateVideoDependencies(Persistence.Entities.Placard entity, Cloud.Api.Common.Models.ComplementationInputModel model)
        {
            var currentVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.VideoComplementContextModel>(entity.SerializedComplementation);

            if (model.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Video)
            {
                var nextVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.VideoComplementContextModel>(model.SerializedComplementation);

                if (currentVideoComplementContextModel.Video.Id == nextVideoComplementContextModel.Video.Id) return;

                entity.VideoBridges.Add(new Persistence.Entities.PlacardVideoBridge
                {
                    Placard = entity,
                    VideoId = nextVideoComplementContextModel.Video.Id
                });
            }

            var currentBridge = entity.VideoBridges.FirstOrDefault(bridge => bridge.VideoId == currentVideoComplementContextModel.Video.Id);

            if (currentBridge == null) return;

            entity.VideoBridges.Remove(currentBridge);
        }

        private void UpdateSoundDependencies(Persistence.Entities.Placard entity, Cloud.Api.Common.Models.ComplementationInputModel model)
        {
            var currentSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.SoundComplementContextModel>(entity.SerializedComplementation);

            if (model.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Sound)
            {
                var nextSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.SoundComplementContextModel>(model.SerializedComplementation);

                if (currentSoundComplementContextModel.Sound.Id == nextSoundComplementContextModel.Sound.Id) return;

                entity.SoundBridges.Add(new Persistence.Entities.PlacardSoundBridge
                {
                    Placard = entity,
                    SoundId = nextSoundComplementContextModel.Sound.Id
                });
            }

            var currentBridge = entity.SoundBridges.FirstOrDefault(bridge => bridge.SoundId == currentSoundComplementContextModel.Sound.Id);

            if (currentBridge == null) return;

            entity.SoundBridges.Remove(currentBridge);
        }
    }
}
