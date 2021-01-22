namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class ImageDetailPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<Presentation.Models.View.ImageViewModel> editRequestActionCallback;

        public ImageDetailPage(Presentation.Models.View.ImageViewModel model, System.Action<Presentation.Models.View.ImageViewModel> editRequestActionCallback = null)
        {
            InitializeComponent();

            BindingContext = model;

            if (editRequestActionCallback == null)
            {
                ToolbarItems.Clear();
            }
            else
            {
                this.editRequestActionCallback = editRequestActionCallback;
            }
        }

        private void EditToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            editRequestActionCallback.Invoke(BindingContext as Presentation.Models.View.ImageViewModel);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            editRequestActionCallback = null;
        }
    }
}