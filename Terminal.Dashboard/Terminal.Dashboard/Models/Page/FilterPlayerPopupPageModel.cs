using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class FilterPlayerPopupPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string name;

        public FilterPlayerPopupPageModel()
        {
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }
    }
}
