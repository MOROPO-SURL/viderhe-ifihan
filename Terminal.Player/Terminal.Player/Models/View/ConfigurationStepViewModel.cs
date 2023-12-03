namespace MOROPO.VIDERHE.Terminal.Player.Models.View
{
    public class ConfigurationStepViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string title;
        private SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView detailContentView;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView DetailContentView { get => detailContentView; set => SetProperty(ref detailContentView, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            DetailContentView.Dispose();

            DetailContentView = null;
        }
    }
}
