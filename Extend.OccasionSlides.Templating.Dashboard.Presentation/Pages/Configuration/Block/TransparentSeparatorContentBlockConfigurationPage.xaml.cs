using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class TransparentSeparatorContentBlockConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<TransparentSeparatorContentBlockConfigurationPageModel>
    {
        private System.Action<TransparentSeparatorContentBlockViewModel> applyCallbackAction;

        public TransparentSeparatorContentBlockConfigurationPage(System.Action<TransparentSeparatorContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TransparentSeparatorContentBlockConfigurationPage(TransparentSeparatorContentBlockViewModel model, System.Action<TransparentSeparatorContentBlockViewModel> applyCallbackAction)
            : base(TransparentSeparatorContentBlockConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque Separador Transparente" : "Agregar Bloque Separador Transparente";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                SizingMode = BindingContextPageModel.SizingMode
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
    }
}