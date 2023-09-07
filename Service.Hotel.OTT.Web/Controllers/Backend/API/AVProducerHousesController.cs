using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class AVProducerHousesController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<AVProducerHouse, System.Guid, AVProducerHouseInputModel, AVProducerHouseDisplayModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager;

        public AVProducerHousesController(Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<AVProducerHouse, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AVProducerHousesController> localizer, ILogger<AVProducerHousesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Authorization.AVProducerHouseViewerPermission)]
        public override ActionResult<AVProducerHouseDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.AVProducerHouseViewerPermission)]
        public override ActionResult<AVProducerHouseDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.AVProducerHouseViewerPermission)]
        public override ActionResult<Framework.Guama.Core.Presentation.Models.PaginationModel<AVProducerHouseDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.AVProducerHouseCreatorPermission)]
        public override ActionResult Create([FromBody] AVProducerHouseInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.AVProducerHouseEditorPermission)]
        public override ActionResult Edit([FromBody] AVProducerHouseInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.AVProducerHouseRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override AVProducerHouseDisplayModel EntityToDisplayModel(AVProducerHouse entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Image != null)
            {
                model.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(AVProducerHouse entity, AVProducerHouseInputModel model)
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
                                About = string.Format("Image for AVProducerHouse: {0}", model.Id)
                            };
                            entity.Identity.ImageId = entity.Identity.Image.Id;

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.ImageContent, entity.Identity.Image.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PreEdit(AVProducerHouse entity, AVProducerHouseInputModel model)
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
                                About = string.Format("Image for AVProducerHouse: {0}", model.Id)
                            }, User.Identity.Name, false);
                            entity.Identity.ImageId = entity.Identity.Image.Id;

                            imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, model.ImageContent, entity.Identity.Image.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PostEdit(AVProducerHouse entity, AVProducerHouseInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.ImageContent != null && model.ImageId != null)
            {
                var deprecatedImage = imageRepository.Get(model.ImageId.Value);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(AVProducerHouse entity)
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
