namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models
{
    public class TextContentBlockModel : XFToolKit.Mvvm.Models.BaseBindableModel, System.ICloneable
    {
        private int priority;
        private string header;
        private int headerFontSize;
        private bool isHeaderVisible;
        private string content;
        private int contentMaxLine;
        private int contentFontSize;

        public TextContentBlockModel()
        {
            Id = System.Guid.NewGuid();

            contentFontSize = 14;
            headerFontSize = 12;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Header { get => header; set => SetProperty(ref header, value); }

        public int HeaderFontSize { get => headerFontSize; set => SetProperty(ref headerFontSize, value); }

        public bool IsHeaderVisible { get => isHeaderVisible; set => SetProperty(ref isHeaderVisible, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public int ContentMaxLine { get => contentMaxLine; set => SetProperty(ref contentMaxLine, value); }

        public int ContentFontSize { get => contentFontSize; set => SetProperty(ref contentFontSize, value); }

        public object Clone()
        {
            return new TextContentBlockModel
            {
                Id = Id,
                Priority = Priority,
                Header = Header,
                HeaderFontSize = HeaderFontSize,
                IsHeaderVisible = IsHeaderVisible,
                Content = Content,
                ContentMaxLine = ContentMaxLine,
                ContentFontSize = ContentFontSize
            };
        }
    }
}
