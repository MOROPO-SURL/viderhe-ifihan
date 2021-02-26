[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers.PlatfromIntegrationHelper))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.Helpers
{
    public class PlatfromIntegrationHelper : Extend.Common.Overlaying.Presentation.Helpers.Facade.IPlatformIntegrationHelperFacade
    {
        public System.Threading.Tasks.Task LaunchApplication(string discriminator)
        {
            throw new System.NotImplementedException();
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
