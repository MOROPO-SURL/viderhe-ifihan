using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class CategoriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Category, System.Guid, CategoryInputModel, CategoryDisplayModel>
    {
        public CategoriesController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Category, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<CategoriesController> localizer, ILogger<CategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.CategoryViewerPermission)]
        public override ActionResult<CategoryDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.CategoryViewerPermission)]
        public override ActionResult<CategoryDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.CategoryViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<CategoryDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.CategoryCreatorPermission)]
        public override ActionResult Create([FromBody] CategoryInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.CategoryEditorPermission)]
        public override ActionResult Edit([FromBody] CategoryInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.CategoryRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }
    }
}
