using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page.Popup
{
    public class PlacardFilterPopupPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string label;

        public PlacardFilterPopupPageModel()
        {
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public string Label { get => label; set => SetProperty(ref label, value); }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }
    }
}
