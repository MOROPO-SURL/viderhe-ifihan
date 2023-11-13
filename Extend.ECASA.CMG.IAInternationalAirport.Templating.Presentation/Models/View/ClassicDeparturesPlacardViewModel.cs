using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using System.Collections.ObjectModel;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View
{
    public class ClassicDeparturesPlacardViewModel : Contract.AbstractDeparturesPlacardViewModel
    {
        private ObservableCollection<OperationDisplayModel> items;

        public Xamarin.Forms.Color BackgroundColor { get; set; }

        public Xamarin.Forms.Color TableHeaderTextColor { get; set; }

        public Xamarin.Forms.Color TableHeaderBackgroundColor { get; set; }

        public Xamarin.Forms.Color PrimaryRowTextColor { get; set; }

        public Xamarin.Forms.Color PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public Xamarin.Forms.Color SecoundaryRowTextColor { get; set; }

        public Xamarin.Forms.Color SecoundaryRowBackgroundColor { get; set; }

        public ObservableCollection<OperationDisplayModel> Items { get => items; set => SetProperty(ref items, value); }
    }
}
