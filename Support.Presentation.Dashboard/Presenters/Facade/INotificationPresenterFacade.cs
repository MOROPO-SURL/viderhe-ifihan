namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade
{
    public interface INotificationPresenterFacade
    {
        void PresentNotification(string title, string message, bool unnattended = true);
    }
}
