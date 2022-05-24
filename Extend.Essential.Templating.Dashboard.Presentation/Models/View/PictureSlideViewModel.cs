namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.View
{
    public class PictureSlideViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private Enumerations.PictureLayoutMode layoutMode;

        public PictureSlideViewModel()
        {
            LayoutMode = Enumerations.PictureLayoutMode.AspectFill;

            AvailableLayoutModes = new Enumerations.PictureLayoutMode[] 
            { Enumerations.PictureLayoutMode.AspectFit, 
                Enumerations.PictureLayoutMode.AspectFill, 
                Enumerations.PictureLayoutMode.Fill, 
                Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf 
            };
        }

        public Support.Presentation.Models.View.ImageViewModel Image { get; set; }

        public Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => SetProperty(ref layoutMode, value); }

        public Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }
    }
}
