namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class StatusInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Status, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Discriminator { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Label { get; set; }

        public Persistence.Entities.Status Export()
        {
            var entity = new Persistence.Entities.Status();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Status entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Status entity)
        {
            entity.Discriminator = Discriminator;
            entity.Label = Label;
        }
    }
}
