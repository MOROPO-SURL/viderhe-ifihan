using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class CountriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Country, System.Guid, CountryInputModel, CountryDisplayModel>
    {
        public CountriesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Country, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CountriesController> localizer, ILogger<CountriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.CountryViewerPermission)]
        public override ActionResult<CountryDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.CountryViewerPermission)]
        public override ActionResult<CountryDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.CountryViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<CountryDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.CountryCreatorPermission)]
        public override ActionResult Create([FromBody] CountryInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.CountryEditorPermission)]
        public override ActionResult Edit([FromBody] CountryInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.CountryRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }
    }
}
