namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions
{
    public static class TextContentBlockModelExtensions
    {
        public static Models.View.TextContentBlockViewModel ToViewModel(this Templating.Models.Context.TextContentBlockContextModel target)
        {
            return new Models.View.TextContentBlockViewModel
            {
                Id = target.Id,
                Priority = target.Priority,
                IsHeaderVisible = target.IsHeaderVisible,
                Header = target.Header,
                HeaderFontFamily = target.HeaderFontFamily,
                HeaderFontSize = target.HeaderFontSize,
                Content = target.Content,
                ContentFontFamily = target.ContentFontFamily,
                ContentFontSize = target.ContentFontSize,
                ContentMaxLine = target.ContentMaxLine
            };
        }

        public static Templating.Models.Context.TextContentBlockContextModel ToContextModel(this Models.View.TextContentBlockViewModel target)
        {
            return new Templating.Models.Context.TextContentBlockContextModel
            {
                Id = target.Id,
                Priority = target.Priority,
                IsHeaderVisible = target.IsHeaderVisible,
                Header = target.Header,
                HeaderFontFamily = target.HeaderFontFamily,
                HeaderFontSize = target.HeaderFontSize,
                Content = target.Content,
                ContentFontFamily = target.ContentFontFamily,
                ContentFontSize = target.ContentFontSize,
                ContentMaxLine = target.ContentMaxLine
            };
        }
    }
}
