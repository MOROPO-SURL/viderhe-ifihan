using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Pages
{
    public partial class WindowsAppsLauncherPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        public WindowsAppsLauncherPage(WindowsAppsLauncherOverlayViewModel model)
        {
            InitializeComponent();

            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            BackgroundImageSource = Xamarin.Forms.ImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.AppsLauncherPageBackground.jpg", GetType().Assembly);

            LogoImage.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.MF-Identity-Landscape.svg", GetType().Assembly);

            TitleLabel.Text = model.Title;
            TitleLabel.TextColor = accountInformationProvider.SecoundaryColor;

            BindingContext = model;

            Xamarin.Forms.Device.StartTimer(System.TimeSpan.FromMinutes(3), () =>
            {
                if (BindingContext != null)
                {
                    this.NavigationPopModalPageAsync();
                }

                return false;
            });
        }

        private void LaunchLabelTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            Xamarin.Forms.DependencyService.Get<Common.Overlaying.Presentation.Helpers.Facade.IPlatformIntegrationHelperFacade>()?.LaunchApplication(((sender as Xamarin.Forms.BindableObject).BindingContext as WindowsAppLaunchViewModel).LocalPath);

            this.NavigationPopModalPageAsync();
        }

        private void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BackgroundImageSource = null;
            LogoImage.Source = null;
        }
    }
}