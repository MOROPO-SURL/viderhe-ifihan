namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class StatusDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Status, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Discriminator { get; set; }

        public string Label { get; set; }

        public void Import(Persistence.Entities.Status entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Discriminator = entity.Discriminator;
        }
    }
}
