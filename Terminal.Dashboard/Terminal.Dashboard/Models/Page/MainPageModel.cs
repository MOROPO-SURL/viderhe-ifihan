namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class MainPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public MainPageModel()
        {
            Actions = new System.Collections.ObjectModel.ObservableCollection<View.ActionViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.ActionViewModel> Actions { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Actions.Clear();

            Actions = null;
        }
    }
}
