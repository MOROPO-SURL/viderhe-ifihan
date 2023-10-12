namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class KindInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Kind, Persistence.Enumerations.OperationKind>
    {
        public Persistence.Enumerations.OperationKind Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Discriminator { get; set; }

        public Persistence.Entities.Kind Export()
        {
            var entity = new Persistence.Entities.Kind { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Kind entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Kind entity)
        {
            entity.Discriminator = Discriminator;
        }
    }
}
