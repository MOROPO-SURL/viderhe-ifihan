namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class ImageContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private double heightByScreenVerticalSizePercent;
        private Support.Presentation.Models.View.ImageViewModel image;
        private Essential.Templating.Enumerations.PictureLayoutMode layoutMode;
        private Xamarin.Forms.LayoutAlignment horizontalAlignament;

        public ImageContentBlockConfigurationPageModel()
        {
            horizontalAlignament = Xamarin.Forms.LayoutAlignment.Center;
            heightByScreenVerticalSizePercent = 30;

            AvailableLayoutModes = new Essential.Templating.Enumerations.PictureLayoutMode[]
            {
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFit,
                Essential.Templating.Enumerations.PictureLayoutMode.AspectFill,
                Essential.Templating.Enumerations.PictureLayoutMode.Fill
            };

            AvailableContentHorizontalAlignaments = new Xamarin.Forms.LayoutAlignment[]
            {
                Xamarin.Forms.LayoutAlignment.Center,
                Xamarin.Forms.LayoutAlignment.Start,
                Xamarin.Forms.LayoutAlignment.End
            };
        }

        public System.Guid Id { get; set; }

        public double HeightByScreenVerticalSizePercent { get => heightByScreenVerticalSizePercent; set => SetProperty(ref heightByScreenVerticalSizePercent, value); }

        public Support.Presentation.Models.View.ImageViewModel Image { get => image; set => SetProperty(ref image, value); }

        public Essential.Templating.Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => SetProperty(ref layoutMode, value); }

        public Xamarin.Forms.LayoutAlignment HorizontalAlignament { get => horizontalAlignament; set => SetProperty(ref horizontalAlignament, value); }

        public Enumerations.ImageFilterKind? FilterKind { get; set; }

        public string FilterSerializationContext { get; set; }

        public Essential.Templating.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        public Xamarin.Forms.LayoutAlignment[] AvailableContentHorizontalAlignaments { get; private set; }
    }
}
