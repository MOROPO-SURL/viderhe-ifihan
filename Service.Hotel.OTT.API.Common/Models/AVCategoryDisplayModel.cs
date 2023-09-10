namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVCategoryDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AVCategory, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AVCategoryDisplayModel Parent { get; set; }

        public void Import(Persistence.Entities.AVCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public override string ToString()
        {
            return ComputeFullName();
        }

        protected string ComputeFullName()
        {
            if (Parent == null) return Name;

            return string.Format("{0} > {1}", Parent.ComputeFullName(), Name);
        }
    }
}
