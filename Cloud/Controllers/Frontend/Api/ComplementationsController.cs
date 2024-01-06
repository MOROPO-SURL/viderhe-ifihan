using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class ComplementationsController : Controller
    {
        private readonly IEntityRepository<Placard, System.Guid> repository;

        public ComplementationsController(IEntityRepository<Placard, System.Guid> repository)
        {
            this.repository = repository;
        }

        [HttpPut]
        public virtual ActionResult Edit([FromBody] ComplementationInputModel model)
        {
            try
            {
                var entity = repository.Get(model.PlacardId);

                if (entity.ComplementationKind == PlacardComplementationKind.Video)
                {
                    UpdateVideoDependencies(entity, model);
                }
                else if (entity.ComplementationKind == PlacardComplementationKind.Sound)
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

        private void UpdateVideoDependencies(Placard entity, ComplementationInputModel model)
        {
            var currentVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoComplementContextModel>(entity.SerializedComplementation);

            if (model.ComplementationKind == PlacardComplementationKind.Video)
            {
                var nextVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoComplementContextModel>(model.SerializedComplementation);

                if (currentVideoComplementContextModel.Video.Id == nextVideoComplementContextModel.Video.Id) return;

                entity.VideoBridges.Add(new PlacardVideoBridge
                {
                    Prow = entity,
                    SternId = nextVideoComplementContextModel.Video.Id
                });
            }

            var currentBridge = entity.VideoBridges.FirstOrDefault(bridge => bridge.SternId == currentVideoComplementContextModel.Video.Id);

            if (currentBridge == null) return;

            entity.VideoBridges.Remove(currentBridge);
        }

        private void UpdateSoundDependencies(Placard entity, ComplementationInputModel model)
        {
            var currentSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundComplementContextModel>(entity.SerializedComplementation);

            if (model.ComplementationKind == PlacardComplementationKind.Sound)
            {
                var nextSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundComplementContextModel>(model.SerializedComplementation);

                if (currentSoundComplementContextModel.Sound.Id == nextSoundComplementContextModel.Sound.Id) return;

                entity.SoundBridges.Add(new PlacardSoundBridge
                {
                    Prow = entity,
                    SternId = nextSoundComplementContextModel.Sound.Id
                });
            }

            var currentBridge = entity.SoundBridges.FirstOrDefault(bridge => bridge.SternId == currentSoundComplementContextModel.Sound.Id);

            if (currentBridge == null) return;

            entity.SoundBridges.Remove(currentBridge);
        }
    }
}
