using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class FrameDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Frame, long>
    {
        public long Id { get; set; }

        public PlacardDisplayModel Placard { get; set; }

        public int Priority { get; set; }

        public void Import(Frame entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;

            Placard = new PlacardDisplayModel();

            Placard.Import(entity.Placard);
        }
    }
}
