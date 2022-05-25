namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context
{
    public class TextContentBlockContextModel
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public string Header { get; set; }

        public string HeaderFontFamily { get; set; }

        public int HeaderFontSize { get; set; }

        public bool IsHeaderVisible { get; set; }

        public string Content { get; set; }

        public int ContentMaxLine { get; set; }

        public string ContentFontFamily { get; set; }

        public int ContentFontSize { get; set; }
    }
}
