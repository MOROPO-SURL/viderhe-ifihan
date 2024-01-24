using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Pages
{
    public partial class NMTourPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action presentationCompleteCallbackAction;

        private System.Collections.Generic.List<Models.Context.NMTourOverlaySectionContextModel> sections;

        public NMTourPage(Models.Context.NMTourOverlayContextModel model, System.Action presentationCompleteCallbackAction)
        {
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;

            InitializeComponent();

            sections = new System.Collections.Generic.List<Models.Context.NMTourOverlaySectionContextModel>(model.Sections);

            BindingContext = new Models.Page.NMTourPageModel
            {
                Title = model.Title,
                About = model.About,
                BannerImageSource = Support.Presentation.Factories.ImageUriFactory.BuildImageUri(model.BannerImage.Id)
            };

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            IsEnabled = true;

            System.Threading.Tasks.Task.Delay(100).ContinueWith(_ =>
            {
                while (sections.Count > 0)
                {
                    var option = sections.First();

                    sections.RemoveAt(0);

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() => 
                    {
                        (BindingContext as Models.Page.NMTourPageModel).Sections.Add(option);
                    });

                    if (sections.Count > 0) System.Threading.Thread.Sleep(200);
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            presentationCompleteCallbackAction?.Invoke();

            presentationCompleteCallbackAction = null;

            sections = null;
        }

        private void SectionLaunchButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var model = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.Context.NMTourOverlaySectionContextModel;

            this.NavigationPushModalPageAsync(new WebPortalPage(new Models.Page.WebPortalPageModel
            {
                Title = model.Title,
                Url = new System.Uri(model.Action),
                IsNavigationEnabled = true
            }));
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}