using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard
{
    public class ClassicOperationsSinglePlacardViewModel : Contract.AbstractClassicOperationsPlacardViewModel
    {
        private ObservableCollection<OperationDisplayModel> items;

        public ClassicOperationsSinglePlacardViewModel()
        {
            Items = new ObservableCollection<OperationDisplayModel>();
        }

        public ObservableCollection<OperationDisplayModel> Items { get => items; set => SetProperty(ref items, value); }
    }
}
