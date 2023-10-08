namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class TagPickPopupPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public TagPickPopupPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.TagDisplayModel> Items { get; set; }
    }
}
