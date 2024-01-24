using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page
{
    public class NMTourOverlayConfigurationPageModel : AdvicesMarqueeOverlayConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel bannerImage;
        private string title;
        private string about;

        public NMTourOverlayConfigurationPageModel()
        {
            Sections = new ObservableCollection<Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel>();
        }

        public Support.Presentation.Models.View.ImageViewModel BannerImage { get => bannerImage; set => SetProperty(ref bannerImage, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public ObservableCollection<Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel> Sections { get; set; }
    }
}
