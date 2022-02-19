using System;

[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers.PlatfromIntegrationHelper))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers
{
    public class PlatfromIntegrationHelper : Extend.Common.Overlaying.Presentation.Helpers.Facade.IPlatformIntegrationHelperFacade
    {
        public async System.Threading.Tasks.Task LaunchApplication(string discriminator)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["action"] = "start-proccess";
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["discriminator"] = discriminator;

                await Windows.ApplicationModel.FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }
        }

        public System.Threading.Tasks.Task OpenDocument(string path)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task OpenDocument(System.IO.Stream documentStream)
        {
            throw new System.NotImplementedException();
        }
    }
}
