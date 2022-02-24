using Windows.ApplicationModel.AppService;
using System;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.UWP.DesktopExtension.Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        [System.Runtime.InteropServices.DllImport("User32.dll", SetLastError = true)]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetWindowPos(System.IntPtr Wnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 SWP_SHOWWINDOW = 0x0040;

        private AppServiceConnection appServiceConnection;
        private System.Diagnostics.Process launchProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (launchProcess == null)
            {
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
                        if (launchProcess != null)
                        {
                            ReleaseLaunchProcess();
                        }

                        var discriminator = Windows.Storage.ApplicationData.Current.LocalSettings.Values["discriminator"] as string;

                        var launchaAppProcessStartInfo = new System.Diagnostics.ProcessStartInfo(discriminator)
                        {
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized
                        };

                        launchProcess = System.Diagnostics.Process.Start(launchaAppProcessStartInfo);

                        launchProcess.WaitForInputIdle();

                        SwitchToThisWindow(launchProcess.MainWindowHandle, true);
                        //SetWindowPos(launchProcess.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

                        appServiceConnection = new AppServiceConnection
                        {
                            AppServiceName = "SupportInteropService",
                            PackageFamilyName = Windows.ApplicationModel.Package.Current.Id.FamilyName
                        };

                        appServiceConnection.OpenAsync().AsTask();

                        break;

                    default:
                        break;
                }
            }
            else
            {
                ReleaseLaunchProcess();

                appServiceConnection.SendMessageAsync(new Windows.Foundation.Collections.ValueSet()).AsTask();

                Close();
            }
        }

        private void ReleaseLaunchProcess()
        {
            launchProcess.Close();

            launchProcess.Dispose();

            launchProcess = null;
        }
    }
}
