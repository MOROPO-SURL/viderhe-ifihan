using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Pages
{
    public partial class NMTourOverlaySectionConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.NMTourOverlaySectionConfigurationPageModel>
    {
        private System.Action<Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel> applyCallbackAction;

        public NMTourOverlaySectionConfigurationPage(System.Action<Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public NMTourOverlaySectionConfigurationPage(Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel model, System.Action<Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel> applyCallbackAction)
            : base(Factories.NMTourOverlaySectionConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Sección Interactiva" : "Agregar Sección Interactiva";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel
            {
                Glyph = BindingContextPageModel.Glyph,
                Title = BindingContextPageModel.Title,
                Action = BindingContextPageModel.Action.ToString()
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

        private void GlyphPicked_Callback(string selection)
        {
            BindingContextPageModel.Glyph = selection;
        }
    }
}