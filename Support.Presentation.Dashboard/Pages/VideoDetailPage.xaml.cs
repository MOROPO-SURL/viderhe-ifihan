namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class VideoDetailPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<Presentation.Models.View.VideoViewModel> editRequestActionCallback;

        public VideoDetailPage(Presentation.Models.View.VideoViewModel model, System.Action<Presentation.Models.View.VideoViewModel> editRequestActionCallback = null)
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

            editRequestActionCallback.Invoke(BindingContext as Presentation.Models.View.VideoViewModel);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            editRequestActionCallback = null;
        }
    }
}