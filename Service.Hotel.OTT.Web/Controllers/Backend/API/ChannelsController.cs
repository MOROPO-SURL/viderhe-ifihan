using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Controllers.Backend.API
{
    public class ChannelsController : Framework.Guama.Core.Presentation.Web.API.Controllers.AbstractEntityApiManagementController<Channel, System.Guid, ChannelInputModel, ChannelDisplayModel>
    {
        public ChannelsController(IEntityRepository<Channel, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ChannelsController> localizer, ILogger<ChannelsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override ChannelDisplayModel EntityToDisplayModel(Channel entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.FeatureImageExtension = entity.FeatureImage == null ? null : MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);

            return model;
        }
    }
}
