namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.View
{
    public class PictureSlideViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private Templating.Presentation.Enumerations.PictureLayoutMode layoutMode;

        public PictureSlideViewModel()
        {
            LayoutMode = Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill;

            AvailableLayoutModes = new Templating.Presentation.Enumerations.PictureLayoutMode[] { Templating.Presentation.Enumerations.PictureLayoutMode.AspectFit, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill, Templating.Presentation.Enumerations.PictureLayoutMode.Fill, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf };
        }

        public Support.Presentation.Models.View.ImageViewModel Image { get; set; }

        public Templating.Presentation.Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => SetProperty(ref layoutMode, value); }

        public Templating.Presentation.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }
    }
}
