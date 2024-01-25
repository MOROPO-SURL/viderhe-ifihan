namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories
{
    public static class AVCategoryDefinitionPageModelFactory
    {
        public static Models.Page.AVCategoryDefinitionPageModel Build(Service.Hotel.OTT.API.Common.Models.AVCategoryDisplayModel target)
        {
            if (target == null) return new Models.Page.AVCategoryDefinitionPageModel();

            return new Models.Page.AVCategoryDefinitionPageModel
            {
                Id = target.Id,
                Name = target.Name,
                Parent = target.Parent
            };
        }
    }
}
