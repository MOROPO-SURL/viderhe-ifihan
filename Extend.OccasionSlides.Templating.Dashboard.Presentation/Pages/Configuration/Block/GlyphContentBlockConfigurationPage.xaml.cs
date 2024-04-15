using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class GlyphContentBlockConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<GlyphContentBlockConfigurationPageModel>
    {
        private System.Action<GlyphContentBlockViewModel> applyCallbackAction;

        public GlyphContentBlockConfigurationPage(System.Action<GlyphContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public GlyphContentBlockConfigurationPage(GlyphContentBlockViewModel model, System.Action<GlyphContentBlockViewModel> applyCallbackAction)
            : base(Factories.Block.GlyphContentBlockConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque de Símbolo" : "Agregar Bloque de Símbolo";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new GlyphContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                Glyph = BindingContextPageModel.Glyph,
                FontSize = BindingContextPageModel.FontSize,
                Color = BindingContextPageModel.Color
            });

            this.NavigationPopPageAsync();
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea cancelar?", "Cancelar", "Continuar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
            });
        }

        private void PickGlyphButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.GlyphPickPage(GlyphPicked_Callback));
        }

        private void ColorButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.ColorPickPopUpPage(ColorPicked_Callback, BindingContextPageModel.Color));
        }

        private void ColorPicked_Callback(Xamarin.Forms.Color color)
        {
            BindingContextPageModel.Color = color;
        }

        private void GlyphPicked_Callback(string selection)
        {
            BindingContextPageModel.Glyph = selection;
        }
    }
}