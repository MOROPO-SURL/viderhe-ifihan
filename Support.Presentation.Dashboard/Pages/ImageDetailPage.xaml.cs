using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class ImageDetailPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<ImageViewModel> editRequestActionCallback;

        public ImageDetailPage(ImageViewModel model, System.Action<ImageViewModel> editRequestActionCallback = null)
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
            editRequestActionCallback.Invoke(BindingContext as ImageViewModel);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            editRequestActionCallback = null;
        }
    }
}