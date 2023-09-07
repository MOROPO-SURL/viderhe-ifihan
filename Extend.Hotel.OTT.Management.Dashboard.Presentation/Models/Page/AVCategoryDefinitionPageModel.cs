using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVCategoryDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private AVCategoryDisplayModel parent;

        public AVCategoryDefinitionPageModel()
        {
            AvailableCategories = new System.Collections.ObjectModel.ObservableCollection<AVCategoryDisplayModel>();
        }

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public AVCategoryDisplayModel Parent { get => parent; set => SetProperty(ref parent, value); }

        public System.Collections.ObjectModel.ObservableCollection<AVCategoryDisplayModel> AvailableCategories { get; private set; }
    }
}
