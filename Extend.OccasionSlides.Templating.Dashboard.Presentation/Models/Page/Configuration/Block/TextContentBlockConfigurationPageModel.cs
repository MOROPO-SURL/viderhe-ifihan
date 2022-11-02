namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class TextContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string text;
        private int textMaxLineCount;
        private string textFontFamily;
        private int textFontSize;
        private Xamarin.Forms.Color textColor;

        public TextContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            textFontSize = 21;
            textMaxLineCount = 1;
        }

        public System.Guid Id { get; set; }

        public string Text { get => text; set => SetProperty(ref text, value); }

        public int TextMaxLineCount { get => textMaxLineCount; set => SetProperty(ref textMaxLineCount, value); }

        public string TextFontFamily { get => textFontFamily; set => SetProperty(ref textFontFamily, value); }

        public int TextFontSize { get => textFontSize; set => SetProperty(ref textFontSize, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => textColor = value; }
    }
}
