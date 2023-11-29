using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Presenters
{
    public class NotificationPresenter : INotificationPresenterFacade
    {
        public void PresentNotification(string title, string message, bool unnattended = true)
        {
            if (unnattended)
            {
                var notificator = Xamarin.Forms.DependencyService.Get<Plugin.Toasts.IToastNotificator>();

                var options = new Plugin.Toasts.NotificationOptions
                {
                    Title = title,
                    Description = message,
                    ClearFromHistory = true
                };

                notificator.Notify(options);
            }
            else
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, "Aceptar");
            }
        }
    }
}
