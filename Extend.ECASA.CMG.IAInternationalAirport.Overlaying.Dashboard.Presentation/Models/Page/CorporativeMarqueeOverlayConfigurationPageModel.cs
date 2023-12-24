using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Enumerations;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Models.Page
{
    public class CorporativeMarqueeOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private bool isRectangle19x6LogoSizeModeSelected;
        private bool isRectangle4x3LogoSizeModeSelected;
        private bool isRectangle1x1LogoSizeModeSelected;
        private CorporativeInformationSourceKind? informationSourceKind;
        private string informationSourceFieldPlaceholder;
        private double informationSourceFieldRequestHeight;
        private string informationSource;
        private int informationSourceUpdateMinuteInterval;
        private string head;
        private string tail;
        private string separator;
        private string failbackMessage;
        private bool isRemoteRelatedFieldFamilyVisiable;
        private Xamarin.Forms.Color backgroundColor;
        private Xamarin.Forms.Color textColor;
        private Xamarin.Forms.Color frontierColor;
        private Xamarin.Forms.Color logoOutlineColor;
        private bool isDateTimePresentationRequired;

        public CorporativeMarqueeOverlayConfigurationPageModel()
        {
            isRectangle19x6LogoSizeModeSelected = true;
            isRectangle4x3LogoSizeModeSelected = false;
            isRectangle1x1LogoSizeModeSelected = false;

            AvaiableCorporativeInformationSourceKinds = new CorporativeInformationSourceKind[]
            {
                CorporativeInformationSourceKind.Managed,
                CorporativeInformationSourceKind.RSS
            };

            InformationSourceUpdateMinuteInterval = 20;

            BackgroundColor = Xamarin.Forms.Color.White;
            TextColor = Xamarin.Forms.Color.Black;
            FrontierColor = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().PrimaryColor;
            LogoOutlineColor = Xamarin.Forms.Color.LightGray;

            IsDateTimePresentationRequired = true;

            Separator = "||";

            AccountLogoImageSource = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().LogoImageSource;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            AccountLogoImageSource = null;
        }

        public Xamarin.Forms.ImageSource AccountLogoImageSource { get; private set; }

        public bool IsRectangle19x6LogoSizeModeSelected { get => isRectangle19x6LogoSizeModeSelected; set => SetProperty(ref isRectangle19x6LogoSizeModeSelected, value, IsRectangle19x6LogoSizeModeSelected_Changed); }

        public bool IsRectangle4x3LogoSizeModeSelected { get => isRectangle4x3LogoSizeModeSelected; set => SetProperty(ref isRectangle4x3LogoSizeModeSelected, value, IsRectangle4x3LogoSizeModeSelected_Changed); }

        public bool IsRectangle1x1LogoSizeModeSelected { get => isRectangle1x1LogoSizeModeSelected; set => SetProperty(ref isRectangle1x1LogoSizeModeSelected, value, IsRectangle1x1LogoSizeModeSelected_Changed); }

        public CorporativeInformationSourceKind? InformationSourceKind { get => informationSourceKind; set => SetProperty(ref informationSourceKind, value, InformationSourceKind_Changed); }

        public CorporativeInformationSourceKind[] AvaiableCorporativeInformationSourceKinds { get; private set; }

        public string InformationSourceFieldPlaceholder { get => informationSourceFieldPlaceholder; private set => SetProperty(ref informationSourceFieldPlaceholder, value); }

        public double InformationSourceFieldRequestHeight { get => informationSourceFieldRequestHeight; private set => SetProperty(ref informationSourceFieldRequestHeight, value); }

        public string InformationSource { get => informationSource; set => SetProperty(ref informationSource, value); }

        public int InformationSourceUpdateMinuteInterval { get => informationSourceUpdateMinuteInterval; set => SetProperty(ref informationSourceUpdateMinuteInterval, value); }

        public string Head { get => head; set => SetProperty(ref head, value); }

        public string Tail { get => tail; set => SetProperty(ref tail, value); }

        public string Separator { get => separator; set => SetProperty(ref separator, value); }

        public string FailbackMessage { get => failbackMessage; set => SetProperty(ref failbackMessage, value); }

        public bool IsRemoteRelatedFieldFamilyVisiable { get => isRemoteRelatedFieldFamilyVisiable; private set => SetProperty(ref isRemoteRelatedFieldFamilyVisiable, value); }

        public Xamarin.Forms.Color BackgroundColor { get => backgroundColor; set => SetProperty(ref backgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public Xamarin.Forms.Color FrontierColor { get => frontierColor; set => SetProperty(ref frontierColor, value); }

        public Xamarin.Forms.Color LogoOutlineColor { get => logoOutlineColor; set => SetProperty(ref logoOutlineColor, value); }

        public bool IsDateTimePresentationRequired { get => isDateTimePresentationRequired; set => SetProperty(ref isDateTimePresentationRequired, value); }

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

        internal void InformationSourceKind_Changed()
        {
            switch (InformationSourceKind)
            {
                case CorporativeInformationSourceKind.Managed:
                    IsRemoteRelatedFieldFamilyVisiable = false;
                    InformationSourceFieldPlaceholder = "Especifique el texto a presentar ...";
                    InformationSourceFieldRequestHeight = 200;

                    break;

                case CorporativeInformationSourceKind.RSS:
                default:
                    IsRemoteRelatedFieldFamilyVisiable = true;
                    InformationSourceFieldPlaceholder = "Especifique la dirección de internet de la fuente de noticias ...";
                    InformationSourceFieldRequestHeight = 32;

                    break;
            }
        }
    }
}
