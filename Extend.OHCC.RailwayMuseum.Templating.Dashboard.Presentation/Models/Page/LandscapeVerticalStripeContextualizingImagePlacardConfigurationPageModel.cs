namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool isContextedImageZoomingEnabled;
        private Templating.Presentation.Enumerations.ColorBackgroundMode stripeColorBackgroundMode;
        private bool isStripeBackgroundTranslucent;
        private string header;
        private int headerFontSize;
        private string content;
        private int contentFontSize;

        public LandscapeVerticalStripeContextualizingImagePlacardConfigurationPageModel()
        {
            StripeColorBackgroundMode = Templating.Presentation.Enumerations.ColorBackgroundMode.Primary;

            AvailableStripeColorBackgroundModes = new Templating.Presentation.Enumerations.ColorBackgroundMode[]
            {
                Templating.Presentation.Enumerations.ColorBackgroundMode.Primary,
                Templating.Presentation.Enumerations.ColorBackgroundMode.Secoundary
            };

            HeaderFontSize = 48;
            ContentFontSize = 32;
        }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool IsContextedImageZoomingEnabled { get => isContextedImageZoomingEnabled; set => SetProperty(ref isContextedImageZoomingEnabled, value); }

        public Templating.Presentation.Enumerations.ColorBackgroundMode StripeColorBackgroundMode { get => stripeColorBackgroundMode; set => SetProperty(ref stripeColorBackgroundMode, value); }

        public Templating.Presentation.Enumerations.ColorBackgroundMode[] AvailableStripeColorBackgroundModes { get; private set; }

        public bool IsStripeBackgroundTranslucent { get => isStripeBackgroundTranslucent; set => SetProperty(ref isStripeBackgroundTranslucent, value); }

        public string Header { get => header; set => SetProperty(ref header, value); }

        public int HeaderFontSize { get => headerFontSize; set => SetProperty(ref headerFontSize, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public int ContentFontSize { get => contentFontSize; set => SetProperty(ref contentFontSize, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
