using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page.Popup
{
    public class PlayerFilterPopupPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string name;

        public PlayerFilterPopupPageModel()
        {
            Tags = new System.Collections.ObjectModel.ObservableCollection<TagDisplayModel>();
        }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public System.Collections.ObjectModel.ObservableCollection<TagDisplayModel> Tags { get; set; }
    }
}
