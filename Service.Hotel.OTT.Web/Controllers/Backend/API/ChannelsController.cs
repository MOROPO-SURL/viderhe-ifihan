using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = AspNetCore.Authentication.ApiKey.ApiKeyDefaults.AuthenticationScheme)]
    [Route("api/backend/[controller]")]
    [ApiController]
    public class ChannelsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Channel, System.Guid, ChannelInputModel, ChannelDisplayModel>
    {
        private readonly IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository;
        private readonly Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager;

        public ChannelsController(Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManager, IEntityRepository<Framework.Guama.Media.Persistence.Entities.Image, System.Guid> imageRepository, IEntityRepository<Channel, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ChannelsController> localizer, ILogger<ChannelsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Authorization.ChannelViewerPermission)]
        public override ActionResult<ChannelDisplayModel[]> Get()
        {
            return base.Get();
        }

        [RequirePermissions(Authorization.ChannelViewerPermission)]
        public override ActionResult<ChannelDisplayModel> Get(System.Guid key)
        {
            return base.Get(key);
        }

        [RequirePermissions(Authorization.ChannelViewerPermission)]
        public override ActionResult<PaginationModel<ChannelDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
        {
            return base.GetPaginate(sheet, limit);
        }

        [RequirePermissions(Authorization.ChannelCreatorPermission)]
        public override ActionResult Create([FromBody] ChannelInputModel inputModel)
        {
            return base.Create(inputModel);
        }

        [RequirePermissions(Authorization.ChannelEditorPermission)]
        public override ActionResult Edit([FromBody] ChannelInputModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Authorization.ChannelRemoverPermission)]
        public override ActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        protected override ChannelDisplayModel EntityToDisplayModel(Channel entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.FeatureImage != null)
            {
                model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
            }

            return model;
        }

        protected override void PreCreate(Channel entity, ChannelInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.FeatureImageContent != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImageContent))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.FeatureImage = new Framework.Guama.Media.Persistence.Entities.Image
                            {
                                ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.FeatureImageExtension),
                                Length = model.FeatureImageContent.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Channel: {0}", model.Id)
                            };
                            entity.FeatureImageId = entity.FeatureImage.Id;

                            imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImageContent, entity.FeatureImage.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PreEdit(Channel entity, ChannelInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.FeatureImageContent != null)
            {
                using (var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImageContent))
                {
                    using (var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream))
                    {
                        using (var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData))
                        {
                            entity.FeatureImage = imageRepository.Add(new Framework.Guama.Media.Persistence.Entities.Image
                            {
                                ContentType = MimeTypes.MimeTypeMap.GetMimeType(model.FeatureImageExtension),
                                Length = model.FeatureImageContent.LongLength,
                                Width = imageSkBitmap.Width,
                                Height = imageSkBitmap.Height,
                                About = string.Format("Image for Channel: {0}", model.Id)
                            }, User.Identity.Name, false);
                            entity.FeatureImageId = entity.FeatureImage.Id;

                            imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImageContent, entity.FeatureImage.ContentType);
                        }
                    }
                }
            }
        }

        protected override void PostEdit(Channel entity, ChannelInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.FeatureImageContent != null && model.FeatureImageId != null)
            {
                var deprecatedImage = imageRepository.Get(model.FeatureImageId.Value);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(Channel entity)
        {
            base.PostDelete(entity);

            if (entity.FeatureImageId != null)
            {
                imageRepository.Delete(entity.FeatureImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(entity.FeatureImage);
            }
        }
    }
}
