using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class UserAuthenticationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.UserAuthenticationPageModel>
    {
        public UserAuthenticationPage() : base(new Models.Page.UserAuthenticationPageModel { TargetCloudHostName = Managers.SessionManager.Instance.Server })
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
            {
                if (task.Result)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Xamarin.Forms.DependencyService.Get<Managers.Facade.IApplicationManagerFacade>().Quit();
                    });
                }
            });

            return true;
        }

        private void SignButton_Clicked(object sender, System.EventArgs e)
        {
            BindingContextPageModel.IsBusy = true;

            Managers.SessionManager.Instance.SignInAsync(BindingContextPageModel.TargetCloudHostName, BindingContextPageModel.UserName, BindingContextPageModel.Password).ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    System.Exception targetException = task.Exception;

                    while (targetException is System.AggregateException)
                    {
                        targetException = targetException.InnerException;
                    }

                    var message = "Problemas no esperados en el sistema.";

                    if (targetException is System.Net.Http.HttpRequestException)
                    {
                        message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
                    }
                    else if (targetException is SAPRESSC.Core.Api.Connect.UnspectedHttpStatusException)
                    {
                        var unspectedHttpStatus = (targetException as SAPRESSC.Core.Api.Connect.UnspectedHttpStatusException).HttpStatusCode;

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
                    }

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.IsBusy = false;

                        DisplayAlert("Error", message, "Aceptar");
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    this.NavigationPopModalPageAsync();
                });
            });
        }
    }
}