using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter
{
    public class ScheduledRelaunchFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<ScheduledRelaunch, System.Guid>
    {
        [Required, RegularExpression(@"^[0-9A-Z]{7}$")]
        public string PlayerId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<ScheduledRelaunch, bool>> GetSelector()
        {
            return entity => entity.PlayerId == PlayerId;
        }
    }
}
