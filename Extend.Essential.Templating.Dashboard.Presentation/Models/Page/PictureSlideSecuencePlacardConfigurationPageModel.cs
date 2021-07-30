namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PictureSlideSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private int picturePresentationSecounds;

        public PictureSlideSecuencePlacardConfigurationPageModel()
        {
            PicturePresentationSecounds = 10;

            AvailableLayoutModes = new Templating.Presentation.Enumerations.PictureLayoutMode[] { Templating.Presentation.Enumerations.PictureLayoutMode.AspectFit, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill, Templating.Presentation.Enumerations.PictureLayoutMode.Fill, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf };

            Slides = new System.Collections.ObjectModel.ObservableCollection<View.PictureSlideViewModel>();
        }

        public int PicturePresentationSecounds
        {
            get => picturePresentationSecounds;
            set => SetProperty(ref picturePresentationSecounds, value);
        }

        public Templating.Presentation.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public System.Collections.ObjectModel.ObservableCollection<View.PictureSlideViewModel> Slides { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Slides.Clear();

            Slides = null;
        }
    }
}
