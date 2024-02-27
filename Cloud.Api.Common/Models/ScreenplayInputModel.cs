using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class ScreenplayInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Screenplay, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string About { get; set; }

        public Screenplay Export()
        {
            var entity = new Screenplay();

            Mergue(entity);

            return entity;
        }

        public void Import(Screenplay entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            About = entity.About;
        }

        public void Mergue(Screenplay entity)
        {
            entity.Title = Title;
            entity.About = About;
        }
    }
}
