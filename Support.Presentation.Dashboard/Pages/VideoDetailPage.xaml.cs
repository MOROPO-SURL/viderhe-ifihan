using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class VideoDetailPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<VideoViewModel> editRequestActionCallback;

        public VideoDetailPage(VideoViewModel model, System.Action<VideoViewModel> editRequestActionCallback = null)
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

        private void EditToolbarItem_Activated(object sender, System.EventArgs e)
        {
            VideoPlayer.Pause();

            editRequestActionCallback.Invoke(BindingContext as VideoViewModel);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            editRequestActionCallback = null;
        }
    }
}