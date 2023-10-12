namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CategoryInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Category, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Discriminator { get; set; }

        public Persistence.Entities.Category Export()
        {
            var entity = new Persistence.Entities.Category();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Category entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Category entity)
        {
            entity.Name = Name;
            entity.Discriminator = Discriminator;
        }
    }
}
