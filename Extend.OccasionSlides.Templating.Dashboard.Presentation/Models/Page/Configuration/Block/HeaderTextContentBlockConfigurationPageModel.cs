namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class HeaderTextContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private int priority;
        private string header;
        private string headerFontFamily;
        private int headerFontSize;
        private Xamarin.Forms.Color headerColor;
        private string text;
        private int textMaxLineCount;
        private string textFontFamily;
        private int textFontSize;
        private Xamarin.Forms.Color textColor;

        public HeaderTextContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            textFontSize = 21;
            textMaxLineCount = 1;
            headerFontSize = 16;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string HeaderFontFamily { get => headerFontFamily; set => SetProperty(ref headerFontFamily, value); }

        public int HeaderFontSize { get => headerFontSize; set => SetProperty(ref headerFontSize, value); }

        public Xamarin.Forms.Color HeaderColor { get => headerColor; set => headerColor = value; }

        public string Text { get => text; set => SetProperty(ref text, value); }

        public int TextMaxLineCount { get => textMaxLineCount; set => SetProperty(ref textMaxLineCount, value); }

        public string TextFontFamily { get => textFontFamily; set => SetProperty(ref textFontFamily, value); }

        public int TextFontSize { get => textFontSize; set => SetProperty(ref textFontSize, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => textColor = value; }
    }
}
