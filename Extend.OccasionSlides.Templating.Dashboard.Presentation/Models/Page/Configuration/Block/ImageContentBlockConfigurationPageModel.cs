namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class ImageContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private double heightByScreenVerticalSizePercent;
        private Support.Presentation.Models.View.ImageViewModel image;
        private Essential.Templating.Enumerations.PictureLayoutMode layoutMode;
        private Enumerations.ContentHorizontalAlignament horizontalAlignament;

        public ImageContentBlockConfigurationPageModel()
        {
            AvailableLayoutModes = new Essential.Templating.Enumerations.PictureLayoutMode[]
            {
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFit,
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFill,
                Essential.Templating.Enumerations.PictureLayoutMode.Fill,
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };

            AvailableContentHorizontalAlignaments = new Enumerations.ContentHorizontalAlignament[]
            {
                Enumerations.ContentHorizontalAlignament.Center,
                Enumerations.ContentHorizontalAlignament.Left,
                Enumerations.ContentHorizontalAlignament.Right
            };
        }

        public double HeightByScreenVerticalSizePercent { get => heightByScreenVerticalSizePercent; set => SetProperty(ref heightByScreenVerticalSizePercent, value); }

        public Support.Presentation.Models.View.ImageViewModel Image { get => image; set => image = value; }

        public Essential.Templating.Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => layoutMode = value; }

        public Enumerations.ContentHorizontalAlignament HorizontalAlignament { get => horizontalAlignament; set => horizontalAlignament = value; }

        public Enumerations.ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }

        public Essential.Templating.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public Enumerations.ContentHorizontalAlignament[] AvailableContentHorizontalAlignaments { get; private set; }
    }
}
