using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class PlacardsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementFilteredController<Placard, System.Guid, PlacardInputModel, PlacardDisplayModel, PlacardFilterModel>
    {
        private System.Collections.Generic.List<System.Guid> relatedScreenplaysIds;

        private readonly IEntityRepository<Account, System.Guid> accountRepository;
        private readonly IEntityRepository<Template, System.Guid> templateRepository;
        private readonly IEntityRepository<Frame, long> frameRepository;

        public PlacardsController(IEntityRepository<Frame, long> frameRepository, IEntityRepository<Template, System.Guid> templateRepository, IEntityRepository<Account, System.Guid> accountRepository, IEntityRepository<Placard, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PlacardsController> localizer, ILogger<PlacardsController> logger) : base(repository, localizer, logger)
        {
            this.accountRepository = accountRepository;
            this.templateRepository = templateRepository;
            this.frameRepository = frameRepository;

            relatedScreenplaysIds = new System.Collections.Generic.List<System.Guid>();
        }

        protected override System.Linq.Expressions.Expression<System.Func<Placard, bool>> GetGlobalSelector()
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            return e => e.Account.Id == accountId && e.Template.Enabled;
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public override ActionResult<PlacardDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        protected override void PreCreate(Placard entity, PlacardInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value));
            entity.Template = templateRepository.Get(inputModel.TemplateId);

            var dependencyImages = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetImages(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyImages != null)
            {
                foreach (var item in dependencyImages)
                {
                    entity.ImageBridges.Add(new PlacardImageBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }

            var dependencyVideos = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetVideos(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyVideos != null)
            {
                foreach (var item in dependencyVideos)
                {
                    entity.VideoBridges.Add(new PlacardVideoBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }

            var dependencyGradients = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetGradients(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyGradients != null)
            {
                foreach (var item in dependencyGradients)
                {
                    entity.GradientBridges.Add(new PlacardGradientBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }

            var dependencySounds = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetSounds(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencySounds != null)
            {
                foreach (var item in dependencySounds)
                {
                    entity.SoundBridges.Add(new PlacardSoundBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }
        }

        protected override void PreEdit(Placard entity, PlacardInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();

            entity.ImageBridges.Clear();
            entity.GradientBridges.Clear();

            var dependencyImages = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetImages(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyImages != null)
            {
                foreach (var item in dependencyImages)
                {
                    entity.ImageBridges.Add(new PlacardImageBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }

            var dependencyGradients = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetGradients(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyGradients != null)
            {
                foreach (var item in dependencyGradients)
                {
                    entity.GradientBridges.Add(new PlacardGradientBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }

            UpdateVideoDependencies(entity, inputModel);

            UpdateSoundDependencies(entity, inputModel);
        }

        protected override void PreDelete(Placard entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();

            var relatedFrames = frameRepository.FindBy(_entity => _entity.PlacardId == entity.Id);

            foreach (var item in relatedFrames)
            {
                if (relatedScreenplaysIds.Contains(item.ScreenplayId)) continue;

                relatedScreenplaysIds.Add(item.ScreenplayId);
            }
        }

        protected override void PostDelete(Placard entity)
        {
            base.PostDelete(entity);

            if (relatedScreenplaysIds.Count <= 0) return;

            foreach (var id in relatedScreenplaysIds)
            {
                var entities = frameRepository.FindBy(_entity => _entity.ScreenplayId == id).OrderBy(_entity => _entity.Priority).ToList();

                if (entities.Count <= 0) return;

                var index = 0;

                while (entities.Count > 1)
                {
                    var next = entities.First();

                    next.Priority = ++index;

                    frameRepository.Update(next, "system", false);

                    entities.RemoveAt(0);
                }

                var last = entities.First();

                last.Priority = index + 1;

                frameRepository.Update(last, "system");
            }
        }

        private void UpdateVideoDependencies(Placard entity, PlacardInputModel inputModel)
        {
            PlacardVideoBridge complementVideoBridge = null;

            if (entity.ComplementationKind == PlacardComplementationKind.Video)
            {
                var currentVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoComplementContextModel>(entity.SerializedComplementation);

                complementVideoBridge = entity.VideoBridges.FirstOrDefault(bridge => bridge.SternId == currentVideoComplementContextModel.Video.Id);
            }

            entity.VideoBridges.Clear();

            if (complementVideoBridge != null) entity.VideoBridges.Add(complementVideoBridge);

            var dependencyVideos = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetVideos(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyVideos != null)
            {
                foreach (var item in dependencyVideos)
                {
                    entity.VideoBridges.Add(new PlacardVideoBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }
        }

        private void UpdateSoundDependencies(Placard entity, PlacardInputModel inputModel)
        {
            PlacardSoundBridge complementSoundBridge = null;

            if (entity.ComplementationKind == PlacardComplementationKind.Sound)
            {
                var currentSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundComplementContextModel>(entity.SerializedComplementation);

                complementSoundBridge = entity.SoundBridges.FirstOrDefault(bridge => bridge.SternId == currentSoundComplementContextModel.Sound.Id);
            }

            entity.SoundBridges.Clear();

            if (complementSoundBridge != null) entity.SoundBridges.Add(complementSoundBridge);

            var dependencySounds = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetSounds(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencySounds != null)
            {
                foreach (var item in dependencySounds)
                {
                    entity.SoundBridges.Add(new PlacardSoundBridge
                    {
                        Prow = entity,
                        SternId = item.Id
                    });
                }
            }
        }
    }
}
