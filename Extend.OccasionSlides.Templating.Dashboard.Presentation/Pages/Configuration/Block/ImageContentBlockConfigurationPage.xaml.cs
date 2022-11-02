using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Block
{
    public partial class ImageContentBlockConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.Configuration.Block.ImageContentBlockConfigurationPageModel>
    {
        private System.Action<Templating.Presentation.Models.View.Block.ImageContentBlockViewModel> applyCallbackAction;

        public ImageContentBlockConfigurationPage(System.Action<Templating.Presentation.Models.View.Block.ImageContentBlockViewModel> applyCallbackAction)
            : this(null, applyCallbackAction)
        {
        }

        public ImageContentBlockConfigurationPage(Templating.Presentation.Models.View.Block.ImageContentBlockViewModel model, System.Action<Templating.Presentation.Models.View.Block.ImageContentBlockViewModel> applyCallbackAction)
            : base(Factories.Block.ImageContentBlockConfigurationPageModelFactory.Build(model))
        {
            this.applyCallbackAction = applyCallbackAction;

            InitializeComponent();

            Title = model != null ? "Modificar Bloque de Imagen" : "Agregar Bloque de Imagen";
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            applyCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            applyCallbackAction.Invoke(new Templating.Presentation.Models.View.Block.ImageContentBlockViewModel
            {
                Id = BindingContextPageModel.Id,
                Image = BindingContextPageModel.Image,
                HorizontalAlignament = BindingContextPageModel.HorizontalAlignament,
                HeightByScreenVerticalSizePercent = BindingContextPageModel.HeightByScreenVerticalSizePercent
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

        private void PickImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(ImagePicked_Callback, BindingContextPageModel.Image));
        }

        private void ImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.Image = selection;
        }
    }
}