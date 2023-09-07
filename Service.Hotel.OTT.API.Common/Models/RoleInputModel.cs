using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class RoleInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Role, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Role Export()
        {
            var entity = new Role();

            Mergue(entity);

            return entity;
        }

        public void Import(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Role entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
