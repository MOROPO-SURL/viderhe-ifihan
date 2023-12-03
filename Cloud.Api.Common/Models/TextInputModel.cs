using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class TextInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Text, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Content { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public Text Export()
        {
            var entity = new Text();

            Mergue(entity);

            return entity;
        }

        public void Import(Text entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Text entity)
        {
            entity.Content = Content;
            entity.About = About;
        }
    }
}
