using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Page
{
    public class NMTourPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public NMTourPageModel()
        {
            Sections = new ObservableCollection<Context.NMTourOverlaySectionContextModel>();
        }

        public Xamarin.Forms.ImageSource BannerImageSource { get; set; }

        public string Title { get; set; }

        public string About { get; set; }

        public ObservableCollection<Context.NMTourOverlaySectionContextModel> Sections { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Sections.Clear();

            Sections = null;
        }
    }
}
