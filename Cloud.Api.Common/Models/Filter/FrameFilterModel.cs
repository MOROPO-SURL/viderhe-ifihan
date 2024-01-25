using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter
{
    public class FrameFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Frame, long>
    {
        public System.Guid ScreenplayId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Frame, bool>> GetSelector()
        {
            return entity => entity.ScreenplayId == ScreenplayId;
        }
    }
}
