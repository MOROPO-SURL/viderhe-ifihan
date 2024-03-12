using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View
{
    public class PlacardOverviewViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private PlacardViewModel reference;
        private PlacardViewModel placard;

        public PlacardOverviewViewModel(PlacardViewModel reference, bool load = true)
        {
            this.reference = reference;

            if (!load) return;

            LoadPlacardModel();
        }

        public PlacardViewModel Placard { get => placard; set => SetProperty(ref placard, value); }

        public void LoadPlacardModel()
        {
            Placard = reference;
        }

        public void ReleasePlacardModel()
        {
            Placard = null;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (Placard != null)
            {
                Placard.Dispose();

                ReleasePlacardModel();
            }

            reference.Dispose();

            reference = null;
        }
    }
}
