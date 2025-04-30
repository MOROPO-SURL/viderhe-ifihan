using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class EditSimpleVideoPlacardPageModel : AbstractLabeledPlacardConfigurationPageModel
    {
        private Enumerations.VideoStrechAspectKind strechAspectKind;
        private bool muted;

        public EditSimpleVideoPlacardPageModel()
        {
            AvailableVideoStrechAspectKinds = new Enumerations.VideoStrechAspectKind[]
            {
                Enumerations.VideoStrechAspectKind.AspectFit,
                Enumerations.VideoStrechAspectKind.AspectFill,
                Enumerations.VideoStrechAspectKind.Fill
            };

            strechAspectKind = Enumerations.VideoStrechAspectKind.AspectFill;
        }

        public VideoViewModel Video { get; set; }

        public Enumerations.VideoStrechAspectKind StrechAspectKind { get => strechAspectKind; set => SetProperty(ref strechAspectKind, value); }

        public bool Muted { get => muted; set => SetProperty(ref muted, value); }

        public Enumerations.VideoStrechAspectKind[] AvailableVideoStrechAspectKinds { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;

            AvailableVideoStrechAspectKinds = null;
        }
    }
}
