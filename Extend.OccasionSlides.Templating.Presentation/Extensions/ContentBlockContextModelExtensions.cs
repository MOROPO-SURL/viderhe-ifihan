using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Models.Context.Block.Contract;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class ContentBlockContextModelExtensions
    {
        public static Models.View.Block.Contract.AbstractContentBlockViewModel ToViewModel(this AbstractContentBlockContextModel target)
        {
            if (target is HeaderTextContentBlockContextModel)
            {
                var concreteTarget = target as HeaderTextContentBlockContextModel;

                return new Models.View.Block.HeaderTextContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Text = concreteTarget.Text,
                    TextColor = Xamarin.Forms.Color.FromHex(concreteTarget.TextColor),
                    TextFontFamily = concreteTarget.TextFontFamily,
                    TextFontSize = concreteTarget.TextFontSize,
                    TextMaxLineCount = concreteTarget.TextMaxLineCount,
                    Header = concreteTarget.Header,
                    HeaderColor = Xamarin.Forms.Color.FromHex(concreteTarget.HeaderColor),
                    HeaderFontFamily = concreteTarget.HeaderFontFamily,
                    HeaderFontSize = concreteTarget.HeaderFontSize
                };
            }

            if (target is TextContentBlockContextModel)
            {
                var concreteTarget = target as TextContentBlockContextModel;

                return new Models.View.Block.TextContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Text = concreteTarget.Text,
                    TextColor = Xamarin.Forms.Color.FromHex(concreteTarget.TextColor),
                    TextFontFamily = concreteTarget.TextFontFamily,
                    TextFontSize = concreteTarget.TextFontSize,
                    TextMaxLineCount = concreteTarget.TextMaxLineCount
                };
            }

            if (target is TransparentSeparatorContentBlockContextModel)
            {
                var concreteTarget = target as TransparentSeparatorContentBlockContextModel;

                return new Models.View.Block.TransparentSeparatorContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    SizingMode = concreteTarget.SizingMode
                };
            }

            if (target is ImageContentBlockContextModel)
            {
                var concreteTarget = target as ImageContentBlockContextModel;

                return new Models.View.Block.ImageContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Image = concreteTarget.Image.ToViewModel(),
                    LayoutMode = concreteTarget.LayoutMode.ToXamarinFormsAspect(),
                    HorizontalAlignament = concreteTarget.HorizontalAlignament?.ToLayoutAlignment() ?? Xamarin.Forms.LayoutAlignment.Fill,
                    HeightByScreenVerticalSizePercent = concreteTarget.HeightByScreenVerticalSizePercent,
                    FilterKind = concreteTarget.FilterKind,
                    FilterSerializationContext = concreteTarget.FilterSerializationContext
                };
            }

            if (target is GlyphContentBlockContextModel)
            {
                var concreteTarget = target as GlyphContentBlockContextModel;

                return new Models.View.Block.GlyphContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Glyph = concreteTarget.Glyph,
                    Color = Xamarin.Forms.Color.FromHex(concreteTarget.Color),
                    FontSize = concreteTarget.FontSize
                };
            }

            throw new System.InvalidOperationException();
        }
    }
}
