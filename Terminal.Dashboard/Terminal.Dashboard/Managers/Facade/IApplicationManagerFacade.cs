namespace MOROPO.VIDERHE.Terminal.Dashboard.Managers.Facade
{
    public interface IApplicationManagerFacade
    {
        void Quit();
        void RequestRequiredPermissions();
        string GetUnhandleExceptionMessage(System.Exception exception);
    }
}
