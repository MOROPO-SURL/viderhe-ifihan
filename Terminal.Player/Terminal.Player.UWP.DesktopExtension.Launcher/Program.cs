namespace Terminal.Player.UWP.DesktopExtension.Launcher
{
    internal class Program
    {
        [System.Runtime.InteropServices.DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(System.IntPtr hHnd);

        [System.Runtime.InteropServices.DllImport("USER32.DLL")]
        public static extern bool SetActiveWindow(System.IntPtr hHnd);

        [System.Runtime.InteropServices.DllImport("USER32.DLL")]
        public static extern bool SetWindowPost(System.IntPtr hHnd, System.IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        internal static void Main(string[] args)
        {
            System.Console.Title = "Viderhe Player Launcher";

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

                case "start-proccess":
                    var discriminator = Windows.Storage.ApplicationData.Current.LocalSettings.Values["discriminator"] as string;

                    var launchaAppProcessStartInfo = new System.Diagnostics.ProcessStartInfo(discriminator)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized
                    };

                    var proccess = System.Diagnostics.Process.Start(launchaAppProcessStartInfo);

                    if (proccess.MainWindowHandle != System.IntPtr.Zero)
                    {
                        SetForegroundWindow(proccess.MainWindowHandle);
                        SetWindowPost(proccess.MainWindowHandle, new System.IntPtr(-1), 0, 0, 0, 0, 0x0001 | 0x0002);
                        SetActiveWindow(proccess.MainWindowHandle);
                    }

                    break;

                default:
                    break;
            }
        }
    }
}