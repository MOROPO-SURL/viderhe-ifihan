using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class FilterPlayerPopupPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
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
