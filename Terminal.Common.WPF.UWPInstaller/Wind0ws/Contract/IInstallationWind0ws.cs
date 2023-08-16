namespace MOROPO.VIDERHE.Terminal.Common.WPF.UWPInstaller.Wind0ws.Contract
{
    public interface IInstallationWind0ws
    {
        void PresentForStarting();

        System.Threading.Tasks.Task PresentForSuccessAync(string message);

        System.Threading.Tasks.Task PresentForFailureAsync(string message);

        void Progress_Callback(Models.View.ProgressDetailViewModel model);
    }
}
