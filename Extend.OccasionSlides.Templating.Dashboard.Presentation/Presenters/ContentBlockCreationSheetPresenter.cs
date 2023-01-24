using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Presenters
{
    internal static class ContentBlockCreationSheetPresenter
    {
        private const string OPTION_COMMON_CANCEL = "Cancelar";
        private const string OPTION_CREATE_CONTENT_BLOCK_TEXT = "Texto";
        private const string OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT = "Texto Encabezado";
        private const string OPTION_CREATE_CONTENT_BLOCK_IMAGE = "Imagen";
        private const string OPTION_CREATE_CONTENT_BLOCK_SEPARATOR_TRANSPARENT = "Separador Transparent";

        internal static void PresentForCreate(Xamarin.Forms.Page page, System.Action<AbstractContentBlockViewModel> callbackAction)
        {
            var options = new string[] { 
                OPTION_CREATE_CONTENT_BLOCK_TEXT, 
                OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT, 
                OPTION_CREATE_CONTENT_BLOCK_IMAGE,
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

                        default:
                            break;
                    }
                });
            });
        }

        internal static void PresentForEdit(AbstractContentBlockViewModel target, Xamarin.Forms.Page page, System.Action<AbstractContentBlockViewModel> callbackAction)
        {
            if (target is Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.HeaderTextContentBlockConfigurationPage(target as Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel, callbackAction));

                return;
            }

            if (target is Templating.Presentation.Models.View.Block.TextContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.TextContentBlockConfigurationPage(target as Templating.Presentation.Models.View.Block.TextContentBlockViewModel, callbackAction));

                return;
            }

            if (target is Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.TransparentSeparatorContentBlockConfigurationPage(target as Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel, callbackAction));

                return;
            }

            if (target is Templating.Presentation.Models.View.Block.ImageContentBlockViewModel)
            {
                page.NavigationPushPageAsync(new Pages.Configuration.Block.ImageContentBlockConfigurationPage(target as Templating.Presentation.Models.View.Block.ImageContentBlockViewModel, callbackAction));

                return;
            }

            throw new System.InvalidOperationException();
        }
    }
}
