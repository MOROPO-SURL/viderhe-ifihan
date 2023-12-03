using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard
{
    public class ClassicOperationsPlacardViewModel : Contract.AbstractPaginableOperationsPlacardViewModel
    {
        private ObservableCollection<OperationDisplayModel> items;

        public ClassicOperationsPlacardViewModel()
        {
            Items = new ObservableCollection<OperationDisplayModel>();
        }

        public Xamarin.Forms.Color TableBackgroundColor { get; set; }

        public Xamarin.Forms.Color TableHeaderTextColor { get; set; }

        public Xamarin.Forms.Color TableHeaderBackgroundColor { get; set; }

        public int TableHeaderFontSize { get; set; }

        public Xamarin.Forms.Color PrimaryRowTextColor { get; set; }

        public Xamarin.Forms.Color PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public Xamarin.Forms.Color SecoundaryRowTextColor { get; set; }

        public Xamarin.Forms.Color SecoundaryRowBackgroundColor { get; set; }

        public int RowFontSize { get; set; }

        public ClassicOperationsColumn[] Columns { get; set; }

        public ObservableCollection<OperationDisplayModel> Items { get => items; set => SetProperty(ref items, value); }

        public BackgroundContextModel Background { get; set; }

        public int ForegroundTransparency { get; set; }
    }
}
