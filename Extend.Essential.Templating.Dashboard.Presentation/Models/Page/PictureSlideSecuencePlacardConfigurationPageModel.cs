using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PictureSlideSecuencePlacardConfigurationPageModel : AbstractLabeledPlacardConfigurationPageModel
    {
        private int picturePresentationSecounds;

        public PictureSlideSecuencePlacardConfigurationPageModel()
        {
            PicturePresentationSecounds = 10;

            AvailableLayoutModes = new Enumerations.PictureLayoutMode[]
            {
                Enumerations.PictureLayoutMode.AspectFit,
                Enumerations.PictureLayoutMode.AspectFill,
                Enumerations.PictureLayoutMode.Fill,
                Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };

            Slides = new System.Collections.ObjectModel.ObservableCollection<PictureSlideViewModel>();
        }

        public int PicturePresentationSecounds
        {
            get => picturePresentationSecounds;
            set => SetProperty(ref picturePresentationSecounds, value);
        }

        public Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<PictureSlideViewModel> Slides { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Slides.Clear();

            Slides = null;
        }
    }
}
