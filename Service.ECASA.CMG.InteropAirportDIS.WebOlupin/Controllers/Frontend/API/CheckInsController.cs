using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Controllers.Frontend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/frontend/[controller]")]
    [ApiController]
    public class CheckInsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiConsultFilteredController<CheckIn, System.Guid, CheckInDisplayModel, CheckInFilterModel>
    {
        public CheckInsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<CheckIn, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CheckInsController> localizer, ILogger<CheckInsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override CheckInDisplayModel EntityToDisplayModel(CheckIn entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Operation.Carrier.Image != null)
            {
                model.Operation.Carrier.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Operation.Carrier.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
