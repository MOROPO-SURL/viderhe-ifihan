using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ScreenplayDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Screenplay, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public void Import(Screenplay entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            About = entity.About;
        }
    }
}
