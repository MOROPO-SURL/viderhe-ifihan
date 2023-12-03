using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class TagPickPopupPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public TagPickPopupPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Items { get; set; }
    }
}
