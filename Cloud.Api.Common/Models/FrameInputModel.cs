using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class FrameInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Frame, long>
    {
        public long Id { get; set; }

        [Required]
        public System.Guid ScreenplayId { get; set; }

        [Required]
        public System.Guid PlacardId { get; set; }

        [Required, Range(1, 10)]
        public int Priority { get; set; }

        public Frame Export()
        {
            var entity = new Frame();

            Mergue(entity);

            return entity;
        }

        public void Import(Frame entity)
        {
            Id = entity.Id;
            ScreenplayId = entity.ScreenplayId;
            PlacardId = entity.PlacardId;
            Priority = entity.Priority;
        }

        public void Mergue(Frame entity)
        {
            entity.Priority = Priority;
        }
    }
}
