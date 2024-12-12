using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;
using System.Linq;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class CheckInsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<CheckIn, System.Guid, CheckInInputModel, CheckInDisplayModel>
    {
        private readonly IEntityRepository<Operation, long> operationRepository;

        public CheckInsController(IEntityRepository<Operation, long> operationRepository, IEntityRepository<CheckIn, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CheckInsController> localizer, ILogger<CheckInsController> logger) : base(repository, localizer, logger)
        {
            this.operationRepository = operationRepository;
        }

        [RequirePermissions(Authorization.CheckInViewerPermission)]
        public override ActionResult<CheckInDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.CheckInViewerPermission)]
        public override ActionResult<CheckInDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.CheckInViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<CheckInDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.CheckInCreatorPermission)]
        public override ActionResult Create([FromBody] CheckInInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.CheckInEditorPermission)]
        public override ActionResult Edit([FromBody] CheckInInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.CheckInRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override CheckInDisplayModel EntityToDisplayModel(CheckIn entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.DepartureOperation.Carrier.Image != null)
            {
                model.DepartureOperation.Carrier.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.DepartureOperation.Carrier.Identity.Image.ContentType);
            }

            return model;
        }

        [RequirePermissions(Authorization.CheckInCreatorPermission, Authorization.CheckInEditorPermission)]
        [HttpPut]
        [Route("[action]")]
        public ActionResult Replace([FromBody] CheckInInputModel[] models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entities = Repository.GetAll().ToArray();

                    for (int i = 0; i < entities.Length; i++)
                    {
                        Repository.Delete(entities[i], User.Identity.Name, models.Length <= 0 && i + 1 == entities.Length);
                    }

                    for (int i = 0; i < models.Length; i++)
                    {
                        var model = models[i];

                        var entity = model.Export();

                        PreCreate(entity, model);

                        Repository.Add(entity, User.Identity.Name, i + 1 == models.Length);
                    }

                    return Ok();
                }
                catch (System.Exception e)
                {
                    logger.LogError(e.InnerException, e.Message);

                    return Conflict();
                }
            }

            return BadRequest(ModelState);
        }

        protected override void PreCreate(CheckIn entity, CheckInInputModel model)
        {
            base.PreCreate(entity, model);

            var departureOperation = operationRepository.Get(entity.DepartureOperationId);

            var arrivalOperation = operationRepository.FindBy(_entity => _entity.KindId == InterFIDS.Persistence.Enumerations.OperationKind.Arrival && _entity.CarrierId == departureOperation.CarrierId && _entity.TerminalId == departureOperation.TerminalId).OrderByDescending(_entity => _entity.Id).First();

            entity.ArrivalOperationId = arrivalOperation.Id;
        }
    }
}
