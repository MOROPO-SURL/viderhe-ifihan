using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ScheduledRelaunchDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<ScheduledRelaunch, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.TimeSpan Time { get; set; }

        public void Import(ScheduledRelaunch entity)
        {
            Id = entity.Id;
            Time = entity.Time;
        }
    }
}
