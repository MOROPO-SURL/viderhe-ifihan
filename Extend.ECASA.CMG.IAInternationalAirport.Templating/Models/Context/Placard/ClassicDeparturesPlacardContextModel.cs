namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard
{
    public class ClassicDeparturesPlacardContextModel : Contract.AbstractDeparturesPlacardContextModel
    {
        public string BackgroundColor { get; set; }

        public string TableHeaderTextColor { get; set; }

        public string TableHeaderBackgroundColor { get; set; }

        public string PrimaryRowTextColor { get; set; }

        public string PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public string SecoundaryRowTextColor { get; set; }

        public string SecoundaryRowBackgroundColor { get; set; }
    }
}
