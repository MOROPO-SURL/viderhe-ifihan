namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Block
{
    public class TextContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private int priority;
        private string header;
        private string headerFontFamily;
        private int headerFontSize;
        private bool isHeaderVisible;
        private string content;
        private int contentMaxLine;
        private string contentFontFamily;
        private int contentFontSize;

        public TextContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            contentFontSize = 14;
            headerFontSize = 12;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Header { get => header; set => SetProperty(ref header, value); }

        public string HeaderFontFamily { get => headerFontFamily; set => SetProperty(ref headerFontFamily, value); }

        public int HeaderFontSize { get => headerFontSize; set => SetProperty(ref headerFontSize, value); }

        public bool IsHeaderVisible { get => isHeaderVisible; set => SetProperty(ref isHeaderVisible, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public int ContentMaxLine { get => contentMaxLine; set => SetProperty(ref contentMaxLine, value); }

        public string ContentFontFamily { get => contentFontFamily; set => SetProperty(ref contentFontFamily, value); }

        public int ContentFontSize { get => contentFontSize; set => SetProperty(ref contentFontSize, value); }
    }
}
