namespace Terminal.Player.UWP.DesktopExtension.Launcher
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            System.Console.Title = "Videre Player Launcher";

            var action = Windows.Storage.ApplicationData.Current.LocalSettings.Values["action"];

            switch (action)
            {
                case "restart":
                    var restartProcessStartInfo = new System.Diagnostics.ProcessStartInfo("shutdown", string.Format("/r /t {0} /c \"Se reiniciará el equipo en {0} segundos por indicaciones de la administración del sistema\"", 10))
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };

                    System.Diagnostics.Process.Start(restartProcessStartInfo);

                    break;

                case "shutdown":
                    var shutdownProcessStartInfo = new System.Diagnostics.ProcessStartInfo("shutdown", string.Format("/s /t {0} /c \"Se apagará el equipo en {0} segundos por indicaciones de la administración del sistema\"", 10))
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };

                    System.Diagnostics.Process.Start(shutdownProcessStartInfo);

                    break;

                default:
                    break;
            }
        }
    }
}