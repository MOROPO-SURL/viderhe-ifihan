using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class CarriersController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Carrier, string, CarrierInputModel, CarrierDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public CarriersController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Carrier, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<CarriersController> localizer, ILogger<CarriersController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Authorization.CarrierViewerPermission)]
        public override ActionResult<CarrierDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.CarrierViewerPermission)]
        public override ActionResult<CarrierDisplayModel> Get(string key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.CarrierViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<CarrierDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.CarrierCreatorPermission)]
        public override ActionResult Create([FromBody] CarrierInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.CarrierEditorPermission)]
        public override ActionResult Edit([FromBody] CarrierInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.CarrierRemoverPermission)]
        public override ActionResult Delete(string key)
        {
            return base.Delete(key);
        }

        protected override CarrierDisplayModel EntityToDisplayModel(Carrier entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.ImageId != null)
            {
                model.ImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Carrier entity, CarrierInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.ImageContent != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(model.ImageContent))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.Identity.Image = new Image
                            {
                                ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.ImageExtension),
                                Length = model.ImageContent.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Carrier: {0}", model.Id)
                            };
                            entity.Identity.ImageId = entity.Identity.Image.Id;

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.ImageContent, entity.Identity.Image.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PreEdit(Carrier entity, CarrierInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ImageContent != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(model.ImageContent))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.Identity.Image = imageRepository.Add(new Image
                            {
                                ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.ImageExtension),
                                Length = model.ImageContent.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Carrier: {0}", model.Id)
                            }, User.Identity.Name, false);
                            entity.Identity.ImageId = entity.Identity.Image.Id;

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.ImageContent, entity.Identity.Image.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PostEdit(Carrier entity, CarrierInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.ImageContent != null && model.ImageId != null)
            {
                var deprecatedImage = imageRepository.Get(model.ImageId.Value);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(Carrier entity)
        {
            base.PostDelete(entity);

            if (entity.Identity.ImageId != null)
            {
                imageRepository.Delete(entity.Identity.Image, User.Identity.Name);

                imageFileManager.DeleteImageFile(entity.Identity.Image);
            }
        }
    }
}
