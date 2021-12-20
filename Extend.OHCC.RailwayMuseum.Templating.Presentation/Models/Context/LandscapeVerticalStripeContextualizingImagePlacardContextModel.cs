namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class LandscapeVerticalStripeContextualizingImagePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public bool IsStripeBackgroundTranslucent { get; set; }

        public Enumerations.BackgroundColorMode StripeColorBackgroundMode { get; set; }

        public string Header { get; set; }

        public int HeaderFontSize { get; set; }

        public string Content { get; set; }

        public int ContentFontSize { get; set; }
    }
}
