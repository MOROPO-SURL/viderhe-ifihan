using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard.Contract;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard
{
    public class ClassicOperationsPlacardContextModel : AbstractPaginableOperationsPlacardContextModel
    {
        public string TableBackgroundColor { get; set; }

        public string TableHeaderTextColor { get; set; }

        public string TableHeaderBackgroundColor { get; set; }

        public int TableHeaderFontSize { get; set; }

        public string PrimaryRowTextColor { get; set; }

        public string PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public string SecoundaryRowTextColor { get; set; }

        public string SecoundaryRowBackgroundColor { get; set; }

        public int RowFontSize { get; set; }

        public Enumerations.ClassicOperationsColumn[] Columns { get; set; }

        public BackgroundContextModel Background { get; set; }

        public int ForegroundTransparency { get; set; }
    }
}
