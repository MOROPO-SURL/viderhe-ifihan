using System;

[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers.PlatfromIntegrationHelper))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers
{
    public class PlatfromIntegrationHelper : Extend.Common.Overlaying.Presentation.Helpers.Facade.IPlatformIntegrationHelperFacade
    {
        public async System.Threading.Tasks.Task LaunchApplication(string discriminator)
        {
            var app = Windows.UI.Xaml.Application.Current as App;

            var applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();

            if (app.IsRequestFullScreenModeRequired)
            {
                applicationView.TryEnterFullScreenMode();

                Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.FullScreen;

                app.IsRequestFullScreenModeRequired = false;

                return;
            }

            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["action"] = "start-proccess";
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["discriminator"] = discriminator;

                (Windows.UI.Xaml.Application.Current as App).IsRequestFullScreenModeRequired = true;

                if (applicationView.IsFullScreenMode)
                {
                    applicationView.ExitFullScreenMode();

                    Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.Maximized;

                    app.IsRequestFullScreenModeRequired = true;
                }

                await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();

                
            }
        }

        public System.Threading.Tasks.Task OpenDocument(string path)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task OpenDocument(System.IO.Stream documentStream)
        {
            throw new NotImplementedException();
        }
    }
}
