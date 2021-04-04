using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Pages.PopUp
{
    public partial class NMTourPopUpPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private System.Action presentationCompleteCallbackAction;

        public NMTourPopUpPage(System.Action presentationCompleteCallbackAction)
        {
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;

            InitializeComponent();

            MainImage.Source = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Resources.Image.NM-landscape.jpg", typeof(NMTourPopUpPage).Assembly);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            presentationCompleteCallbackAction?.Invoke();

            presentationCompleteCallbackAction = null;
        }

        private void ProjectWebPortalPresentButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new ProjectWebPortalPage());

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}