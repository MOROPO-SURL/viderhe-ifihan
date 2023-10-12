namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class TerminalDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Terminal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Discriminator { get; set; }

        public void Import(Persistence.Entities.Terminal entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Discriminator = entity.Discriminator;
        }
    }
}
