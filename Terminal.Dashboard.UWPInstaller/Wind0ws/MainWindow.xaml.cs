namespace MOROPO.VIDERHE.Terminal.Dashboard.UWPInstaller.Wind0ws
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, Common.WPF.UWPInstaller.Wind0ws.Contract.IInstallationWind0ws
    {
        private Common.WPF.UWPInstaller.Presenters.InstallationPresenter installationPresenter;

        public MainWindow()
        {
            InitializeComponent();

            installationPresenter = new Common.WPF.UWPInstaller.Presenters.InstallationPresenter(this);
        }

        public void PresentForStarting()
        {
            MainProgressBar.Value = 0;
            MainProgressBar.IsIndeterminate = true;
            MainActionButton.IsEnabled = false;
        }

        public System.Threading.Tasks.Task PresentForSuccessAync(string message)
        {
            Dispatcher.Invoke(() =>
            {
                MainProgressBar.IsIndeterminate = false;

                MainActionButton.IsEnabled = true;

                System.Windows.MessageBox.Show(message, "Listo!");
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task PresentForFailureAsync(string message)
        {
            Dispatcher.Invoke(() =>
            {
                MainProgressBar.IsIndeterminate = false;
                MainProgressBar.Value = 0;

                MainActionButton.IsEnabled = true;

                System.Windows.MessageBox.Show(message, "Aviso!");
            });

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public void Progress_Callback(Common.WPF.UWPInstaller.Models.View.ProgressDetailViewModel model)
        {
            if (MainProgressBar.IsIndeterminate)
            {
                MainProgressBar.IsIndeterminate = false;
            }

            MainProgressBar.Value = model.Percentage;
        }

        private void MainActionButton_Click(object sender, System.Windows.RoutedEventArgs eventArgs)
        {
            installationPresenter.PerformInstallation();
        }
    }
}
