namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class TextInputModel : MOROPO.SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Text, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Content { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string About { get; set; }

        public Persistence.Entities.Text Export()
        {
            var entity = new Persistence.Entities.Text();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Text entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Text entity)
        {
            entity.Content = Content;
            entity.About = About;
        }
    }
}
