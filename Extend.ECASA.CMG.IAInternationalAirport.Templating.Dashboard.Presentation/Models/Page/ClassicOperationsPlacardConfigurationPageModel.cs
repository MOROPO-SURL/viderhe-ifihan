using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page.Contract;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context;
using Xamarin.CommunityToolkit.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page
{
    public class ClassicOperationsPlacardConfigurationPageModel : AbstractPaginableOperationsPlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color headerBackgroundColor;
        private double headerBackgroundColorOpacity;
        private bool isHideHeaderBuildInInfoRequired;
        private BackgroundContextModel headerBackground;
        private bool isRectangle19x6LogoSizeModeSelected;
        private bool isRectangle4x3LogoSizeModeSelected;
        private bool isRectangle1x1LogoSizeModeSelected;
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
        private BackgroundContextModel background;
        private int foregroundTransparency;

        public ClassicOperationsPlacardConfigurationPageModel()
        {
            isRectangle19x6LogoSizeModeSelected = true;
            isRectangle4x3LogoSizeModeSelected = false;
            isRectangle1x1LogoSizeModeSelected = false;

            headerBackgroundColorOpacity = 50;
            headerBackgroundColor = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().PrimaryColor;
            tableBackgroundColor = Xamarin.Forms.Color.Black;
            tableHeaderBackgroundColor = Xamarin.Forms.Color.White;
            tableHeaderTextColor = Xamarin.Forms.Color.Black;
            tableHeaderFontSize = 36;
            primaryRowBackgroundColor = headerBackgroundColor;
            primaryRowTextColor = headerBackgroundColor.ToBlackOrWhiteForText();
            useStrippedRows = false;
            secoundaryRowBackgroundColor = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().SecoundaryColor;
            secoundaryRowTextColor = secoundaryRowBackgroundColor.ToBlackOrWhiteForText();
            rowFontSize = 36;
            ForegroundTransparency = 50;

            AccountLogoImageSource = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().LogoImageSource;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            AccountLogoImageSource = null;
        }

        public Xamarin.Forms.Color HeaderBackgroundColor { get => headerBackgroundColor; set => SetProperty(ref headerBackgroundColor, value); }

        public double HeaderBackgroundOpacity { get => headerBackgroundColorOpacity; set => SetProperty(ref headerBackgroundColorOpacity, value); }

        public bool IsHideHeaderBuildInInfoRequired { get => isHideHeaderBuildInInfoRequired; set => SetProperty(ref isHideHeaderBuildInInfoRequired, value); }

        public BackgroundContextModel HeaderBackground { get => headerBackground; set => SetProperty(ref headerBackground, value); }

        public bool IsRectangle19x6LogoSizeModeSelected { get => isRectangle19x6LogoSizeModeSelected; set => SetProperty(ref isRectangle19x6LogoSizeModeSelected, value, IsRectangle19x6LogoSizeModeSelected_Changed); }

        public bool IsRectangle4x3LogoSizeModeSelected { get => isRectangle4x3LogoSizeModeSelected; set => SetProperty(ref isRectangle4x3LogoSizeModeSelected, value, IsRectangle4x3LogoSizeModeSelected_Changed); }

        public bool IsRectangle1x1LogoSizeModeSelected { get => isRectangle1x1LogoSizeModeSelected; set => SetProperty(ref isRectangle1x1LogoSizeModeSelected, value, IsRectangle1x1LogoSizeModeSelected_Changed); }

        public Xamarin.Forms.ImageSource AccountLogoImageSource { get; set; }

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

        public System.Collections.ObjectModel.ObservableCollection<View.ClassicOperationColumnCollectionItemViewModel> VisibleColumns { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<ClassicOperationsColumn> AvailableColumns { get; set; }

        public BackgroundContextModel Background { get => background; set => SetProperty(ref background, value); }

        public int ForegroundTransparency { get => foregroundTransparency; set => SetProperty(ref foregroundTransparency, value); }

        private void IsRectangle19x6LogoSizeModeSelected_Changed()
        {
            if (IsRectangle19x6LogoSizeModeSelected)
            {
                IsRectangle4x3LogoSizeModeSelected = false;
                IsRectangle1x1LogoSizeModeSelected = false;
            }
        }

        private void IsRectangle4x3LogoSizeModeSelected_Changed()
        {
            if (IsRectangle4x3LogoSizeModeSelected)
            {
                IsRectangle19x6LogoSizeModeSelected = false;
                IsRectangle1x1LogoSizeModeSelected = false;
            }
        }

        private void IsRectangle1x1LogoSizeModeSelected_Changed()
        {
            if (IsRectangle1x1LogoSizeModeSelected)
            {
                IsRectangle4x3LogoSizeModeSelected = false;
                IsRectangle19x6LogoSizeModeSelected = false;
            }
        }
    }
}
