namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Models.View
{
    public class ConfigurationStepViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string title;
        private XFToolKit.Mvvm.Views.ContentView detailContentView;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public XFToolKit.Mvvm.Views.ContentView DetailContentView { get => detailContentView; set => SetProperty(ref detailContentView, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            DetailContentView.Dispose();

            DetailContentView = null;
        }
    }
}
