namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View
{
    public class OverviewViewModel<TModel> : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel where TModel : class, System.IDisposable
    {
        private TModel reference;

        private TModel presented;

        public OverviewViewModel(TModel reference, bool load = true)
        {
            this.reference = reference;

            if (!load) return;

            Present();
        }

        public TModel Presented { get => presented; set => SetProperty(ref presented, value); }

        public void Present()
        {
            Presented = reference;
        }

        public void Unpresent()
        {
            Presented = null;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (Presented != null)
            {
                Presented.Dispose();

                Unpresent();
            }

            reference.Dispose();

            reference = null;
        }
    }
}
