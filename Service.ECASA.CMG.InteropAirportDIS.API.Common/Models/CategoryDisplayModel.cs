namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class CategoryDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Category, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Discriminator { get; set; }

        public void Import(Persistence.Entities.Category entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Discriminator = entity.Discriminator;
        }
    }
}