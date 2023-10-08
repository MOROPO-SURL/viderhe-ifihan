using System.Security.Cryptography.X509Certificates;

namespace MOROPO.VIDERHE.Terminal.Common.WPF.UWPInstaller.Presenters
{
    public class InstallationPresenter
    {
        private readonly Wind0ws.Contract.IInstallationWind0ws installationWind0Ws;

        private System.Threading.CancellationTokenSource actionCancellationTokenSource;

        public InstallationPresenter(Wind0ws.Contract.IInstallationWind0ws installationWind0Ws)
        {
            this.installationWind0Ws = installationWind0Ws;

            actionCancellationTokenSource = new System.Threading.CancellationTokenSource();
        }

        public void PerformInstallation()
        {
            installationWind0Ws.PresentForStarting();

            var progress = new System.Progress<Models.View.ProgressDetailViewModel>(model => installationWind0Ws.Progress_Callback(model));

            System.Threading.Tasks.Task.Run(() =>
            {
                var certificate = new X509Certificate2(System.IO.Path.Combine(System.Environment.CurrentDirectory, "Resources", "Target.cer"));

                var certificateStore = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);

                certificateStore.Open(OpenFlags.ReadWrite);

                var installedCertificates = certificateStore.Certificates.Find(X509FindType.FindBySerialNumber, certificate.SerialNumber, false);

                if (installedCertificates.Count <= 0)
                {
                    certificateStore.Add(certificate);

                    certificateStore.Close();
                }

                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(2));
            }).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    installationWind0Ws.PresentForFailureAsync("No fue posible inicial el proceso de instalación. Por favor intentelo más tarde.");
                }

                actionCancellationTokenSource.TryReset();

                Helpers.AppxBundleSetupHelper.SetupAsync(Enumerations.SetupMode.Install, progress, actionCancellationTokenSource.Token).ContinueWith(_task =>
                {
                    if (_task.IsCanceled || _task.IsFaulted)
                    {
                        installationWind0Ws.PresentForFailureAsync(string.Format("El proceso de instalación no pudo realizarse de forma exitosamente.{0}{0}Detalles:{1}.", System.Environment.NewLine, _task.Exception.Message));
                    }
                    else
                    {
                       if (_task.Result.ExtendedErrorCode != null)
                        {
                            installationWind0Ws.PresentForFailureAsync(string.Format("El proceso de instalación no pudo completarse de forma exitosamente.{0}{0}Detalles:{1}.", System.Environment.NewLine, _task.Result.ErrorText));
                        }
                        else
                        {
                            installationWind0Ws.PresentForSuccessAync(string.Format("El proceso de instalación a concluido exitosamente.{0}{0}Ya puedes disfrutar de la aplicación VIDERHE Control buscándola en el menú Inicio de Windows.", System.Environment.NewLine));
                        }
                    }
                });
            });
        }
    }
}
