[assembly: Xamarin.Forms.Dependency(typeof(MOROPO.VIDERHE.Terminal.Dashboard.UWP.Managers.ApplicationManager))]

namespace MOROPO.VIDERHE.Terminal.Dashboard.UWP.Managers
{
    public class ApplicationManager : Dashboard.Managers.Facade.IApplicationManagerFacade
    {
        public string GetUnhandleExceptionMessage(System.Exception exception)
        {
            return null;
        }

        public void Quit()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }

        public void RequestRequiredPermissions()
        {
        }
    }
}
