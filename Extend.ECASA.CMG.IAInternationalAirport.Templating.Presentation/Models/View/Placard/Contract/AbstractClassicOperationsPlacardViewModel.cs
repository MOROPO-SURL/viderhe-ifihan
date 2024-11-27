using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard.Contract
{
    public class AbstractClassicOperationsPlacardViewModel : AbstractPaginableOperationsPlacardViewModel
    {
        public Xamarin.Forms.Color HeaderBackgroundColor { get; set; }

        public Xamarin.Forms.Color HeaderForegroundColor { get; set; }

        public bool UseCondensedHeaderPresentation { get; set; }

        public bool IsHideHeaderBuildInInfoRequired { get; set; }

        public double HiddenHeaderBuildInInfoHeaderHeight { get; set; }

        public double HeaderBackgroundOpacity { get; set; }

        public BackgroundContextModel HeaderBackground { get; set; }

        public AccountLogoSizeMode LogoSizeMode { get; set; }

        public Xamarin.Forms.Color TableBackgroundColor { get; set; }

        public Xamarin.Forms.Color TableHeaderTextColor { get; set; }

        public Xamarin.Forms.Color TableHeaderBackgroundColor { get; set; }

        public int TableHeaderFontSize { get; set; }

        public bool UseCondensedTextFontFamily { get; set; }

        public Xamarin.Forms.Color PrimaryRowTextColor { get; set; }

        public Xamarin.Forms.Color PrimaryRowBackgroundColor { get; set; }

        public bool UseStrippedRows { get; set; }

        public Xamarin.Forms.Color SecoundaryRowTextColor { get; set; }

        public Xamarin.Forms.Color SecoundaryRowBackgroundColor { get; set; }

        public int RowFontSize { get; set; }

        public ClassicOperationsColumn[] Columns { get; set; }

        public BackgroundContextModel Background { get; set; }

        public int ForegroundTransparency { get; set; }
    }
}
