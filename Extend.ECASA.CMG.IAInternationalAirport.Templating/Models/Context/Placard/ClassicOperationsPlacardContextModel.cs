using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard.Contract;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard
{
    public class ClassicOperationsPlacardContextModel : AbstractPaginableOperationsPlacardContextModel
    {
        public string HeaderBackgroundColor { get; set; }

        public string HeaderForegroundColor { get; set; } = "#FFFFFF";

        public bool UseCondensedHeaderPresentation { get; set; }

        public bool IsHideHeaderBuildInInfoRequired { get; set; }

        public double HiddenHeaderBuildInInfoHeaderHeight { get; set; }

        public double HeaderBackgroundOpacity { get; set; }

        public BackgroundContextModel HeaderBackground { get; set; }

        public Enumerations.AccountLogoSizeMode LogoSizeMode { get; set; }

        public string TableBackgroundColor { get; set; }

        public string TableHeaderTextColor { get; set; }

        public string TableHeaderBackgroundColor { get; set; }

        public int TableHeaderFontSize { get; set; }

        public bool UseCondensedTextFontFamily { get; set; }

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
