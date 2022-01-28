using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class NMTourPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action presentationCompleteCallbackAction;

        public NMTourPage(System.Action presentationCompleteCallbackAction)
        {
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;

            InitializeComponent();

            MainImage.Source = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Resources.Image.NM-landscape.jpg", GetType().Assembly);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            presentationCompleteCallbackAction?.Invoke();

            presentationCompleteCallbackAction = null;
        }

        private void ProjectWebPortalPresentButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ProjectWebPortalPage());
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}