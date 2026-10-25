using MOROPO.VIDERHE.Support.Presentation.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class UserAuthenticationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<UserAuthenticationPageModel>
    {
        public UserAuthenticationPage() : base(new UserAuthenticationPageModel
        { 
            TargetCloudHostName = SessionMemoryManager.Instance.Server,
            TargetCloudProtocolIndex = SessionMemoryManager.Instance.UseSSL ? 0 : 1
        })
        {
            InitializeComponent();

            CopyRightLabel.Text = string.Format("© 2022 - {0} Todos los derechos reservados", System.DateTime.Now.Year < 2024 ? 2024 : System.DateTime.Now.Year);
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
            {
                if (task.Result)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Xamarin.Forms.DependencyService.Get<IApplicationManagerFacade>().Quit();
                    });
                }
            });

            return true;
        }

        private void SignButton_Clicked(object sender, System.EventArgs e)
        {
            BindingContextPageModel.IsBusy = true;

            SessionManager.Instance.SignInAsync(BindingContextPageModel.TargetCloudHostName, BindingContextPageModel.TargetCloudProtocolIndex == 0, BindingContextPageModel.UserName, BindingContextPageModel.Password, SignIn_Callback).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.IsCanceled || task.Exception != null)
                    {
                        var message = "Problemas no esperados en el sistema.";

                        if (task.Exception == null)
                        {
                            message = "El sistema ha tardado demasiado tiempo en responder.";
                        }
                        else
                        {
                            System.Exception targetException = task.Exception;

                            while (targetException is System.AggregateException)
                            {
                                targetException = targetException.InnerException;
                            }

                            if (targetException is System.Net.Http.HttpRequestException || targetException is System.Net.WebException)
                            {
                                message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
                            }
                            else if (targetException is Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException)
                            {
                                var unspectedHttpStatus = (targetException as Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException).HttpStatusCode;

                                if (unspectedHttpStatus == System.Net.HttpStatusCode.BadRequest)
                                {
                                    message = "Datos incorrectos.";
                                }
                                else if (unspectedHttpStatus == System.Net.HttpStatusCode.Forbidden)
                                {
                                    message = "Usuario no autorizado.";
                                }
                                else if (unspectedHttpStatus == System.Net.HttpStatusCode.Unauthorized)
                                {
                                    message = "Usuario y/o contraseña incorrectos.";
                                }
                                else if (unspectedHttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                                {
                                    message = "Servicio no disponible en este momento.";
                                }
                            }
                            else
                            {
                                var nativeMessage = Xamarin.Forms.DependencyService.Get<IApplicationManagerFacade>().GetUnhandleExceptionMessage(targetException);

                                if (nativeMessage != null) message = nativeMessage;
                            }
                        }

                        BindingContextPageModel.IsBusy = false;

                        DisplayAlert("Error", message, "Aceptar");

                        return;
                    }

                    Xamarin.Forms.Application.Current.MainPage = new Xamarin.Forms.NavigationPage(new MainPage());
                });
            });
        }

        private void SignIn_Callback(string message)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                BindingContextPageModel.BusyProgressMessage = message;
            });
        }
    }
}