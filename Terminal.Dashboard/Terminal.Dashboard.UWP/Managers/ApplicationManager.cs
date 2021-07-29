[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Managers.ApplicationManager))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.UWP.Managers
{
    public class ApplicationManager : Dashboard.Managers.Facade.IApplicationManagerFacade
    {
        public void Quit()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }

        public void RequestRequiredPermissions()
        {
        }
    }
}
