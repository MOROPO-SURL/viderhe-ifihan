using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class ContentBlockContextModelExtensions
    {
        public static Models.View.Block.Contract.AbstractContentBlockViewModel ToViewModel(this Templating.Models.Context.Block.Contract.AbstractContentBlockContextModel target)
        {
            if (target is Templating.Models.Context.Block.HeaderTextContentBlockContextModel)
            {
                var concreteTarget = target as Templating.Models.Context.Block.HeaderTextContentBlockContextModel;

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

            if (target is Templating.Models.Context.Block.TextContentBlockContextModel)
            {
                var concreteTarget = target as Templating.Models.Context.Block.TextContentBlockContextModel;

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

            if (target is Templating.Models.Context.Block.TransparentSeparatorContentBlockContextModel)
            {
                var concreteTarget = target as Templating.Models.Context.Block.TransparentSeparatorContentBlockContextModel;

                return new Models.View.Block.TransparentSeparatorContentBlockViewModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    HeightByScreenVerticalSizePercent = concreteTarget.HeightByScreenVerticalSizePercent
                };
            }

            if (target is Templating.Models.Context.Block.ImageContentBlockContextModel)
            {
                var concreteTarget = target as Templating.Models.Context.Block.ImageContentBlockContextModel;

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

            throw new System.InvalidOperationException();
        }
    }
}
