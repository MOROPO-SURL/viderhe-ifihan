using MOROPO.VIDERHE.Terminal.Dashboard.Views.Composite;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class UserProfileImageCroppingPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action<SkiaSharp.SKBitmap> callbackAction;

        private ImageCropperCanvasView imageCropperCanvasView;

        public UserProfileImageCroppingPage(SkiaSharp.SKBitmap target, System.Action<SkiaSharp.SKBitmap> callbackAction)
        {
            InitializeComponent();

            this.callbackAction = callbackAction;

            imageCropperCanvasView = new Views.Composite.ImageCropperCanvasView(target, 1f);

            CropCanvasWrapper.Children.Add(imageCropperCanvasView);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
        {
            callbackAction.Invoke(imageCropperCanvasView.CroppedBitmap.Copy());

            callbackAction = null;
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
        {
            callbackAction.Invoke(null);

            callbackAction = null;
        }

        private void RotateToLeftButton_Clicked(object sender, System.EventArgs args)
        {
            imageCropperCanvasView.RotateToLeft();
        }

        private void RotateToRightButton_Clicked(object sender, System.EventArgs args)
        {
            imageCropperCanvasView.RotateToRight();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            CropCanvasWrapper.Children.Clear();

            imageCropperCanvasView = null;
        }
    }
}