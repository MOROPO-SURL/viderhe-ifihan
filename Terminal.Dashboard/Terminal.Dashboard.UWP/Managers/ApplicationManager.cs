[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Videre.Terminal.Dashboard.UWP.Managers.ApplicationManager))]

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.UWP.Managers
{
    public class ApplicationManager : Dashboard.Managers.Facade.IApplicationManagerFacade
    {
        public void Quit()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }
    }
}
