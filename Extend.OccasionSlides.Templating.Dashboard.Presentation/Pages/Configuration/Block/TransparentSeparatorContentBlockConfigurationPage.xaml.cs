using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class TransparentSeparatorContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.Configuration.Block.TransparentSeparatorContentBlockConfigurationPageModel>
    {
        private System.Action<Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel> applyCallbackAction;

        public TransparentSeparatorContentBlockConfigurationPage(System.Action<Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public TransparentSeparatorContentBlockConfigurationPage(Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel model, System.Action<Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel> applyCallbackAction)
            : base(Factories.Block.TransparentSeparatorContentBlockConfigurationPageModelFactory.Build(model))
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