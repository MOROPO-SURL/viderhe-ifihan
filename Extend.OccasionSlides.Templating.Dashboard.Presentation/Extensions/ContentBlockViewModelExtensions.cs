using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions
{
    public static class ContentBlockViewModelExtensions
    {
        public static Templating.Models.Context.Block.Contract.AbstractContentBlockContextModel ToContextModel(this AbstractContentBlockViewModel target)
        {
            if (target is TextContentBlockViewModel)
            {
                var concreteTarget = target as TextContentBlockViewModel;

                return new Templating.Models.Context.Block.TextContentBlockContextModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Text = concreteTarget.Text,
                    TextColor = concreteTarget.TextColor.ToHex(),
                    TextFontFamily = concreteTarget.TextFontFamily,
                    TextFontSize = concreteTarget.TextFontSize,
                    TextMaxLineCount = concreteTarget.TextMaxLineCount
                };
            }

            if (target is HeaderTextContentBlockViewModel)
            {
                var concreteTarget = target as HeaderTextContentBlockViewModel;

                return new Templating.Models.Context.Block.HeaderTextContentBlockContextModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Text = concreteTarget.Text,
                    TextColor = concreteTarget.TextColor.ToHex(),
                    TextFontFamily = concreteTarget.TextFontFamily,
                    TextFontSize = concreteTarget.TextFontSize,
                    TextMaxLineCount = concreteTarget.TextMaxLineCount,
                    Header = concreteTarget.Header,
                    HeaderColor = concreteTarget.HeaderColor.ToHex(),
                    HeaderFontFamily = concreteTarget.HeaderFontFamily,
                    HeaderFontSize = concreteTarget.HeaderFontSize
                };
            }

            if (target is TransparentSeparatorContentBlockViewModel)
            {
                var concreteTarget = target as TransparentSeparatorContentBlockViewModel;

                return new Templating.Models.Context.Block.TransparentSeparatorContentBlockContextModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    HeightByScreenVerticalSizePercent = concreteTarget.HeightByScreenVerticalSizePercent
                };
            }

            if (target is ImageContentBlockViewModel)
            {
                var concreteTarget = target as ImageContentBlockViewModel;

                return new Templating.Models.Context.Block.ImageContentBlockContextModel
                {
                    Id = concreteTarget.Id,
                    Priority = concreteTarget.Priority,
                    Image = concreteTarget.Image.ToContextModel(),
                    LayoutMode = concreteTarget.LayoutMode.ToPictureLayoutMode(),
                    HorizontalAlignament = concreteTarget.HorizontalAlignament.ToContentHorizontalAlignament(),
                    HeightByScreenVerticalSizePercent = concreteTarget.HeightByScreenVerticalSizePercent,
                    FilterKind = concreteTarget.FilterKind,
                    FilterSerializationContext = concreteTarget.FilterSerializationContext
                };
            }

            throw new System.InvalidOperationException();
        }

        public static void LaunchConfigurationPage(this AbstractContentBlockViewModel target, Xamarin.Forms.Page page, System.Action<AbstractContentBlockViewModel> callbackAction)
        {
            if (target is TextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.TextContentBlockConfigurationPage(target as TextContentBlockViewModel, callbackAction));

                return;
            }

            if (target is HeaderTextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.HeaderTextContentBlockConfigurationPage(target as HeaderTextContentBlockViewModel, callbackAction));

                return;
            }

            //if (target is TransparentSeparatorContentBlockViewModel)
            //{

            //}

            //if (target is ImageContentBlockViewModel)
            //{

            //}

            throw new System.InvalidOperationException();
        }

        public static void Merge(this AbstractContentBlockViewModel target, AbstractContentBlockViewModel source)
        {
            target.Id = source.Id;
            target.Priority = source.Priority;

            if (target is TextContentBlockViewModel)
            {
                var concreteTarget = target as TextContentBlockViewModel;
                var concreteSource = source as TextContentBlockViewModel;

                concreteTarget.Text = concreteSource.Text;
                concreteTarget.TextFontFamily = concreteSource.TextFontFamily;
                concreteTarget.TextFontSize = concreteSource.TextFontSize;
                concreteTarget.TextColor = concreteSource.TextColor;
                concreteTarget.TextMaxLineCount = concreteSource.TextMaxLineCount;
            }

            if (target is HeaderTextContentBlockViewModel)
            {
                var concreteTarget = target as HeaderTextContentBlockViewModel;
                var concreteSource = source as HeaderTextContentBlockViewModel;

                concreteTarget.Header = concreteSource.Header;
                concreteTarget.HeaderFontFamily = concreteSource.HeaderFontFamily;
                concreteTarget.HeaderFontSize = concreteSource.HeaderFontSize;
                concreteTarget.HeaderColor = concreteSource.HeaderColor;

                return;
            }

            //if (target is TransparentSeparatorContentBlockViewModel)
            //{

            //}

            //if (target is ImageContentBlockViewModel)
            //{

            //}

            throw new System.InvalidOperationException();
        }
    }
}
