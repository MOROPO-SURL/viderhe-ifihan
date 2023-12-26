using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Presenters
{
    internal static class ContentBlockCreationSheetPresenter
    {
        private const string OPTION_COMMON_CANCEL = "Cancelar";
        private const string OPTION_CREATE_CONTENT_BLOCK_TEXT = "Texto";
        private const string OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT = "Texto Encabezado";
        private const string OPTION_CREATE_CONTENT_BLOCK_IMAGE = "Imagen";
        private const string OPTION_CREATE_CONTENT_BLOCK_GLYPH = "Símbolo";
        private const string OPTION_CREATE_CONTENT_BLOCK_SEPARATOR_TRANSPARENT = "Separador Transparent";

        internal static void PresentForCreate(Xamarin.Forms.Page page, System.Action<AbstractContentBlockViewModel> callbackAction)
        {
            var options = new string[] {
                OPTION_CREATE_CONTENT_BLOCK_TEXT,
                OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT,
                OPTION_CREATE_CONTENT_BLOCK_IMAGE,
                OPTION_CREATE_CONTENT_BLOCK_GLYPH,
                OPTION_CREATE_CONTENT_BLOCK_SEPARATOR_TRANSPARENT
            };

            page.DisplayActionSheet("Nuevo Bloque de Contenido", OPTION_COMMON_CANCEL, null, options).ContinueWith(actionSheetTask =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    switch (actionSheetTask.Result)
                    {
                        case OPTION_CREATE_CONTENT_BLOCK_TEXT:
                            page.NavigationPushPageAsync(new Pages.Configuration.Block.TextContentBlockConfigurationPage(callbackAction));

                            break;

                        case OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT:
                            page.NavigationPushPageAsync(new Pages.Configuration.Block.HeaderTextContentBlockConfigurationPage(callbackAction));

                            break;

                        case OPTION_CREATE_CONTENT_BLOCK_IMAGE:
                            page.NavigationPushPageAsync(new Pages.Configuration.Block.ImageContentBlockConfigurationPage(callbackAction));

                            break;

                        case OPTION_CREATE_CONTENT_BLOCK_SEPARATOR_TRANSPARENT:
                            page.NavigationPushPageAsync(new Pages.Configuration.Block.TransparentSeparatorContentBlockConfigurationPage(callbackAction));

                            break;

                        case OPTION_CREATE_CONTENT_BLOCK_GLYPH:
                            page.NavigationPushPageAsync(new Pages.Configuration.Block.GlyphContentBlockConfigurationPage(callbackAction));

                            break;

                        default:
                            break;
                    }
                });
            });
        }

        internal static void PresentForEdit(AbstractContentBlockViewModel target, Xamarin.Forms.Page page, System.Action<AbstractContentBlockViewModel> callbackAction)
        {
            if (target is HeaderTextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.HeaderTextContentBlockConfigurationPage(target as HeaderTextContentBlockViewModel, callbackAction));

                return;
            }

            if (target is TextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.TextContentBlockConfigurationPage(target as TextContentBlockViewModel, callbackAction));

                return;
            }

            if (target is TransparentSeparatorContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.TransparentSeparatorContentBlockConfigurationPage(target as TransparentSeparatorContentBlockViewModel, callbackAction));

                return;
            }

            if (target is ImageContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.ImageContentBlockConfigurationPage(target as ImageContentBlockViewModel, callbackAction));

                return;
            }

            if (target is GlyphContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.GlyphContentBlockConfigurationPage(target as GlyphContentBlockViewModel, callbackAction));

                return;
            }

            throw new System.InvalidOperationException();
        }
    }
}
