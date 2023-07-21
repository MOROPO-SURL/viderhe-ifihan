using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class PlacardsController : MOROPO.SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementFilteredController<Persistence.Entities.Placard, System.Guid, PlacardInputModel, PlacardDisplayModel, PlacardFilterModel>
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

            return e => e.Account.Id == accountId && e.Template.Enabled;
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public override ActionResult<PlacardDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        protected override void PreCreate(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            base.PreCreate(entity, inputModel);

            entity.Account = accountRepository.Get(System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value));
            entity.Template = templateRepository.Get(inputModel.TemplateId);

            var dependencyImages = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetImages(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyImages != null)
            {
                foreach (var item in dependencyImages)
                {
                    entity.ImageBridges.Add(new Persistence.Entities.PlacardImageBridge
                    {
                        Placard = entity,
                        ImageId = item.Id
                    });
                }
            }

            var dependencyVideos = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetVideos(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyVideos != null)
            {
                foreach (var item in dependencyVideos)
                {
                    entity.VideoBridges.Add(new Persistence.Entities.PlacardVideoBridge
                    {
                        Placard = entity,
                        VideoId = item.Id
                    });
                }
            }

            var dependencyGradients = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetGradients(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyGradients != null)
            {
                foreach (var item in dependencyGradients)
                {
                    entity.GradientBridges.Add(new Persistence.Entities.PlacardGradientBridge
                    {
                        Placard = entity,
                        GradientId = item.Id
                    });
                }
            }

            var dependencySounds = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetSounds(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencySounds != null)
            {
                foreach (var item in dependencySounds)
                {
                    entity.SoundBridges.Add(new Persistence.Entities.PlacardSoundBridge
                    {
                        Placard = entity,
                        SoundId = item.Id
                    });
                }
            }
        }

        protected override void PreEdit(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            base.PreEdit(entity, inputModel);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();

            entity.ImageBridges.Clear();
            entity.GradientBridges.Clear();

            var dependencyImages = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetImages(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyImages != null)
            {
                foreach (var item in dependencyImages)
                {
                    entity.ImageBridges.Add(new Persistence.Entities.PlacardImageBridge
                    {
                        Placard = entity,
                        ImageId = item.Id
                    });
                }
            }

            var dependencyGradients = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetGradients(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyGradients != null)
            {
                foreach (var item in dependencyGradients)
                {
                    entity.GradientBridges.Add(new Persistence.Entities.PlacardGradientBridge
                    {
                        Placard = entity,
                        GradientId = item.Id
                    });
                }
            }

            UpdateVideoDependencies(entity, inputModel);

            UpdateSoundDependencies(entity, inputModel);
        }

        protected override void PreDelete(Persistence.Entities.Placard entity)
        {
            base.PreDelete(entity);

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            if (entity.Account.Id != accountId) throw new System.InvalidOperationException();
        }
    
        private void UpdateVideoDependencies(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            Persistence.Entities.PlacardVideoBridge complementVideoBridge = null;

            if (entity.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Video)
            {
                var currentVideoComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.VideoComplementContextModel>(entity.SerializedComplementation);

                complementVideoBridge = entity.VideoBridges.FirstOrDefault(bridge => bridge.VideoId == currentVideoComplementContextModel.Video.Id);
            }

            entity.VideoBridges.Clear();

            if (complementVideoBridge != null) entity.VideoBridges.Add(complementVideoBridge);

            var dependencyVideos = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetVideos(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencyVideos != null)
            {
                foreach (var item in dependencyVideos)
                {
                    entity.VideoBridges.Add(new Persistence.Entities.PlacardVideoBridge
                    {
                        Placard = entity,
                        VideoId = item.Id
                    });
                }
            }
        }

        private void UpdateSoundDependencies(Persistence.Entities.Placard entity, PlacardInputModel inputModel)
        {
            Persistence.Entities.PlacardSoundBridge complementSoundBridge = null;

            if (entity.ComplementationKind == Persistence.Enumerations.PlacardComplementationKind.Sound)
            {
                var currentSoundComplementContextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.SoundComplementContextModel>(entity.SerializedComplementation);

                complementSoundBridge = entity.SoundBridges.FirstOrDefault(bridge => bridge.SoundId == currentSoundComplementContextModel.Sound.Id);
            }

            entity.SoundBridges.Clear();

            if (complementSoundBridge != null) entity.SoundBridges.Add(complementSoundBridge);

            var dependencySounds = Support.Extend.Templating.Helpers.Provisioning.PlacardContextDependenciesProvisioningHelper.Instance.GetSounds(inputModel.TemplateId, inputModel.SerializedContext);

            if (dependencySounds != null)
            {
                foreach (var item in dependencySounds)
                {
                    entity.SoundBridges.Add(new Persistence.Entities.PlacardSoundBridge
                    {
                        Placard = entity,
                        SoundId = item.Id
                    });
                }
            }
        }
    }
}
