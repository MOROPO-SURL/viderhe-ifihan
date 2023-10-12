namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class KindDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Kind, Persistence.Enumerations.OperationKind>
    {
        public Persistence.Enumerations.OperationKind Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Discriminator { get; set; }

        public void Import(Persistence.Entities.Kind entity)
        {
            Id = entity.Id;
            Discriminator = entity.Discriminator;
        }
    }
}
