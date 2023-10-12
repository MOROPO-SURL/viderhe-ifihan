namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class TerminalInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Terminal, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Discriminator { get; set; }

        public Persistence.Entities.Terminal Export()
        {
            var entity = new Persistence.Entities.Terminal();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Terminal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Terminal entity)
        {
            entity.Name = Name;
            entity.Discriminator = Discriminator;
        }
    }
}
