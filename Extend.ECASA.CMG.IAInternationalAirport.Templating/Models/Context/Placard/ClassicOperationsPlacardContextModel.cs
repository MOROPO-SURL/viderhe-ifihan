namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard
{
    public class ClassicOperationsPlacardContextModel : Contract.AbstractPaginableOperationsPlacardContextModel
    {
        public string BackgroundColor { get; set; }

        public string TableHeaderTextColor { get; set; }

        public string TableHeaderBackgroundColor { get; set; }

        public int TableHeaderFontSize { get; set; }

        public string PrimaryRowTextColor { get; set; }

        public string PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public string SecoundaryRowTextColor { get; set; }

        public string SecoundaryRowBackgroundColor { get; set; }

        public int RowFontSize { get; set; }
        
        public Enumerations.ClassicDeparturesColumn[] Columns { get; set; }
    }
}
