using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Pages
{
    public partial class InformationContentPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action resetIndleElapsedTimeAction;

        public InformationContentPage(string title, string url, System.Action resetIndleElapsedTimeAction)
        {
            this.resetIndleElapsedTimeAction = resetIndleElapsedTimeAction;

            InitializeComponent();

            IsEnabled = false;

            InformationTitleLabel.Text = title;

            InformationContentWebView.Source = new Xamarin.Forms.UrlWebViewSource { Url = url };
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            resetIndleElapsedTimeAction = null;
        }

        protected override bool OnBackButtonPressed()
        {
            resetIndleElapsedTimeAction?.Invoke();

            return base.OnBackButtonPressed();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();

            this.NavigationPopPageAsync();
        }

        private void InformationContentWebView_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();

            if (!IsEnabled)
            {
                (sender as Xamarin.Forms.WebView).IsEnabled = false;

                BusyView.IsVisible = true;

                IsEnabled = true;

                return;
            }

            eventArgs.Cancel = true;
        }

        private void InformationContentWebView_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs eventArgs)
        {
            (sender as Xamarin.Forms.WebView).IsEnabled = true;

            BusyView.IsVisible = false;
        }

        private void InformationContentWebViewGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void InformationContentWebViewDragGestureRecognizer_DragStarting(object sender, Xamarin.Forms.DragStartingEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void InformationContentWebViewPanGestureRecognizer_PanUpdated(object sender, Xamarin.Forms.PanUpdatedEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void InformationContentWebViewPinchGestureRecognizer_PinchUpdated(object sender, Xamarin.Forms.PinchGestureUpdatedEventArgs eventArgse)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }

        private void InformationContentWebViewSwipeGestureRecognizer_Swiped(object sender, Xamarin.Forms.SwipedEventArgs eventArgs)
        {
            resetIndleElapsedTimeAction?.Invoke();
        }
    }
}