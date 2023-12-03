using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ScheduledRelaunchInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ScheduledRelaunch, System.Guid>
    {
        public System.Guid Id { get; set; }

        [Required, RegularExpression(@"^[0-9A-Z]{7}$")]
        public string PlayerId { get; set; }

        public System.TimeSpan Time { get; set; }

        public ScheduledRelaunch Export()
        {
            var entity = new ScheduledRelaunch
            {
                Id = Id,
                PlayerId = PlayerId
            };

            Mergue(entity);

            return entity;
        }

        public void Import(ScheduledRelaunch entity)
        {
            throw new System.InvalidOperationException();
        }

        public void Mergue(ScheduledRelaunch entity)
        {
            entity.Time = Time;
        }
    }
}
