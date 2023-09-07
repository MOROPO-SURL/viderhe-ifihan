using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class AVGenresController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<AVGenre, int, AVGenreInputModel, AVGenreDisplayModel>
    {
        public AVGenresController(IEntityRepository<AVGenre, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVGenresController> localizer, ILogger<AVGenresController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.AVGenreViewerPermission)]
        public override ActionResult<AVGenreDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.AVGenreViewerPermission)]
        public override ActionResult<AVGenreDisplayModel> Get(int key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.AVGenreViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<AVGenreDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.AVGenreCreatorPermission)]
        public override ActionResult Create([FromBody] AVGenreInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.AVGenreEditorPermission)]
        public override ActionResult Edit([FromBody] AVGenreInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.AVGenreRemoverPermission)]
        public override ActionResult Delete(int key)
        {
            return base.Delete(key);
        }
    }
}
