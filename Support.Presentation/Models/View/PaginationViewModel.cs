namespace MOROPO.VIDERHE.Support.Presentation.Models.View
{
    public class PaginationViewModel<TViewModel> : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private System.Collections.ObjectModel.ObservableCollection<TViewModel> items;

        public System.Collections.ObjectModel.ObservableCollection<TViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private bool isLastPage;

        public bool IsLastPage
        {
            get => isLastPage;
            set => SetProperty(ref isLastPage, value);
        }

        public PaginationViewModel()
        {
            items = new System.Collections.ObjectModel.ObservableCollection<TViewModel>();

            isLastPage = true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            foreach (var item in items)
            {
                if (item is System.IDisposable)
                {
                    (item as System.IDisposable).Dispose();
                }
            }

            items.Clear();

            items = null;
        }
    }
}
