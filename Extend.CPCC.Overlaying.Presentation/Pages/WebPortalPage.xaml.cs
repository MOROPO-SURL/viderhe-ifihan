using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class WebPortalPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<WebPortalPageModel>
    {
        private System.Action resetIndleElapsedTimeAction;

        public WebPortalPage(WebPortalPageModel model, System.Action resetIndleElapsedTimeAction) : base(model)
        {
            this.resetIndleElapsedTimeAction = resetIndleElapsedTimeAction;

            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            resetIndleElapsedTimeAction?.Invoke();

            return base.OnBackButtonPressed();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            resetIndleElapsedTimeAction = null;
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }

        private void WebView_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();

            if (!BindingContextPageModel.IsNavigationEnabled)
            {
                eventArgs.Cancel = true;

                return;
            }

            (sender as Xamarin.Forms.WebView).IsEnabled = false;

            BusyView.IsVisible = true;
        }

        private void WebView_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = true;

            BusyView.IsVisible = false;
        }

        private void WebViewGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void WebViewDragGestureRecognizer_DragStarting(object sender, Xamarin.Forms.DragStartingEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void WebViewPanGestureRecognizer_PanUpdated(object sender, Xamarin.Forms.PanUpdatedEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void WebViewPinchGestureRecognizer_PinchUpdated(object sender, Xamarin.Forms.PinchGestureUpdatedEventArgs eventArgse)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void WebViewSwipeGestureRecognizer_Swiped(object sender, Xamarin.Forms.SwipedEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }
    }
}