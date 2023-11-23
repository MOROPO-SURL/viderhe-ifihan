namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page
{
    public class ClassicOperationsPlacardConfigurationPageModel : Contract.AbstractPaginableOperationsPlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color tableBackgroundColor;
        private Xamarin.Forms.Color tableHeaderTextColor;
        private Xamarin.Forms.Color tableHeaderBackgroundColor;
        private int tableHeaderFontSize;
        private Xamarin.Forms.Color primaryRowTextColor;
        private Xamarin.Forms.Color primaryRowBackgroundColor;
        private bool useStrippedRows;
        private Xamarin.Forms.Color secoundaryRowTextColor;
        private Xamarin.Forms.Color secoundaryRowBackgroundColor;
        private int rowFontSize;
        private Templating.Models.Context.BackgroundContextModel background;
        private int foregroundTransparency;

        public ClassicOperationsPlacardConfigurationPageModel()
        {
            tableBackgroundColor = Xamarin.Forms.Color.Black;
            tableHeaderBackgroundColor = Xamarin.Forms.Color.White;
            tableHeaderTextColor = Xamarin.Forms.Color.Black;
            tableHeaderFontSize = 36;
            primaryRowBackgroundColor = Xamarin.Forms.Color.FromHex("#232323");
            primaryRowTextColor = Xamarin.Forms.Color.White;
            useStrippedRows = false;
            secoundaryRowBackgroundColor = Xamarin.Forms.Color.DimGray;
            secoundaryRowTextColor = Xamarin.Forms.Color.White;
            rowFontSize = 36;            
            ForegroundTransparency = 50;
        }


        public Xamarin.Forms.Color TableBackgroundColor { get => tableBackgroundColor; set => SetProperty(ref tableBackgroundColor, value); }

        public Xamarin.Forms.Color TableHeaderTextColor { get => tableHeaderTextColor; set => SetProperty(ref tableHeaderTextColor, value); }

        public Xamarin.Forms.Color TableHeaderBackgroundColor { get => tableHeaderBackgroundColor; set => SetProperty(ref tableHeaderBackgroundColor, value); }

        public int TableHeaderFontSize { get => tableHeaderFontSize; set => SetProperty(ref tableHeaderFontSize, value); }

        public Xamarin.Forms.Color PrimaryRowTextColor { get => primaryRowTextColor; set => SetProperty(ref primaryRowTextColor, value); }

        public Xamarin.Forms.Color PrimaryRowBackgroundColor { get => primaryRowBackgroundColor; set => SetProperty(ref primaryRowBackgroundColor, value); }

        public bool UseStrippedRows { get => useStrippedRows; set => SetProperty(ref useStrippedRows, value); }

        public Xamarin.Forms.Color SecoundaryRowTextColor { get => secoundaryRowTextColor; set => SetProperty(ref secoundaryRowTextColor, value); }

        public Xamarin.Forms.Color SecoundaryRowBackgroundColor { get => secoundaryRowBackgroundColor; set => SetProperty(ref secoundaryRowBackgroundColor, value); }

        public int RowFontSize { get => rowFontSize; set => SetProperty(ref rowFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<Enumerations.ClassicOperationsColumn> VisibleColumns { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Enumerations.ClassicOperationsColumn> AvailableColumns { get; set; }

        public Templating.Models.Context.BackgroundContextModel Background { get => background; set => SetProperty(ref background, value); }
        
        public int ForegroundTransparency { get => foregroundTransparency; set => SetProperty(ref foregroundTransparency, value); }
    }
}
