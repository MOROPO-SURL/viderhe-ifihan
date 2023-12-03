using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Helpers
{
    internal sealed class SharedExceptionHandleHelper : Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade
    {
        private const string SUPPORT_ORIENTATION_MESSAGE = "Por favor contacte con el servicio de asistencia técnica para notificar esta situación.";

        private static SharedExceptionHandleHelper instance;

        internal static SharedExceptionHandleHelper Instance => instance ?? (instance = new SharedExceptionHandleHelper());

        public void HandleException(System.Exception exception, System.Action continuationCallback = null)
        {
            if (exception == null)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Aviso", string.Format("El sistema ha tardado demasiado tiempo en responder.{1}{1}{0}", SUPPORT_ORIENTATION_MESSAGE, System.Environment.NewLine), "Aceptar").ContinueWith(_ => { continuationCallback?.Invoke(); });

                return;
            }

            var title = "Aviso";

            System.Exception targetException = exception;

            while (targetException is System.AggregateException)
            {
                targetException = targetException.InnerException;
            }

            var message = "Problemas no esperados en el sistema.";

            if (targetException is System.Net.Http.HttpRequestException)
            {
                message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
            }
            else if (targetException is Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException)
            {
                var unspectedHttpStatus = (targetException as Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException).HttpStatusCode;

                if (unspectedHttpStatus == System.Net.HttpStatusCode.BadRequest)
                {
                    message = "Datos del envío incorrectos.";
                }
                else if (unspectedHttpStatus == System.Net.HttpStatusCode.Unauthorized || unspectedHttpStatus == System.Net.HttpStatusCode.NotFound)
                {
                    title = "Acceso denegado.";
                    message = "La información de acceso al servidor especificada no es correcta o válida.";

                    continuationCallback = () =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentConfigureAuthentication);
                    };
                }
                else if (unspectedHttpStatus == System.Net.HttpStatusCode.Forbidden)
                {
                    title = "No Autorizado";
                    message = "Usted no cuenta con los permisos necesarios para realizar esta operación.";

                    continuationCallback = () =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentConfigureAuthentication);
                    };
                }
                else if (unspectedHttpStatus == System.Net.HttpStatusCode.Conflict)
                {
                    message = string.Format("Esta operación no puede realizarse pues compromete la integridad del sistema.{0}{0}Compruebe que el elemento a modificar o eliminar no sea necesario en otras secciones.", System.Environment.NewLine);
                }
            }
            else if (Managers.SessionManager.Instance.HttpClientHelper == null)
            {
                message = "Deben especificarse los datos de conexión al servidor.";

                continuationCallback = () =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentConfigureAuthentication);
                };
            }

            Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, "Aceptar").ContinueWith(task => { continuationCallback?.Invoke(); });
        }

        private void PresentConfigureAuthentication()
        {
            Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new Pages.ServerConectionConfigurationPage());
        }
    }
}
