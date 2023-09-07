using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Extensions
{
    public static class AVCategoryExtensions
    {
        public static void PopulateParent(this AVCategory self, AVCategoryDisplayModel model, Framework.Guama.Core.Persistence.Repositories.IEntityRepository<AVCategory, int> repository)
        {
            model.Parent = new AVCategoryDisplayModel();

            model.Parent.Import(self);

            if (self.ParentId != null)
            {
                repository.Get(self.ParentId.Value).PopulateParent(model.Parent, repository);
            }
        }
    }
}
