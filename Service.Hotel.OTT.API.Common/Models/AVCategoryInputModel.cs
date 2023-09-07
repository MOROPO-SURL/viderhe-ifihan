using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVCategoryInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<AVCategory, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public AVCategory Export()
        {
            var entity = new AVCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(AVCategory entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AVCategory entity)
        {
            entity.Name = Name;
        }
    }
}
