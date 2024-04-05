using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard
{
    public class ClassicOperationsDualPlacardViewModel : Contract.AbstractClassicOperationsPlacardViewModel
    {
        private ObservableCollection<OperationDisplayModel> arraivalItems;
        private ObservableCollection<OperationDisplayModel> departureItems;

        public ClassicOperationsDualPlacardViewModel()
        {
            ArraivalItems = new ObservableCollection<OperationDisplayModel>();
        }

        public ObservableCollection<OperationDisplayModel> ArraivalItems { get => arraivalItems; set => SetProperty(ref arraivalItems, value); }

        public ObservableCollection<OperationDisplayModel> DepartureItems { get => departureItems; set => SetProperty(ref departureItems, value); }
    }
}
