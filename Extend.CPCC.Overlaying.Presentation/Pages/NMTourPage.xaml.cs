using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class NMTourPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action presentationCompleteCallbackAction;

        public NMTourPage(System.Action presentationCompleteCallbackAction)
        {
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;

            InitializeComponent();

            MainImage.Source = Xamarin.Forms.ImageSource.FromResource("MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Resources.Image.NM-landscape.jpg", GetType().Assembly);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            presentationCompleteCallbackAction?.Invoke();

            presentationCompleteCallbackAction = null;
        }

        private void ProjectWebPortalPresentButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushModalPageAsync(new WebPortalPage(new Models.Page.WebPortalPageModel
            {
                Title = "Portal del proyecto Callejón de los Milagros",
                Url = new System.Uri("http://www.elcallejon.net/"),
                IsNavigationEnabled = true
            }));
        }

        private void QRGalleryPresentButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushModalPageAsync(new WebPortalPage(new Models.Page.WebPortalPageModel
            {
                Title = "Galería QR",
                Url = new System.Uri("http://qr.elcallejon.net:8080/"),
                IsNavigationEnabled = true
            }));
        }

        private void CoffePresentButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushModalPageAsync(new WebPortalPage(new Models.Page.WebPortalPageModel
            {
                Title = "Café Nuevo Mundo",
                Url = new System.Uri("http://cafe.elcallejon.net:8080/"),
                IsNavigationEnabled = true
            }));
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}