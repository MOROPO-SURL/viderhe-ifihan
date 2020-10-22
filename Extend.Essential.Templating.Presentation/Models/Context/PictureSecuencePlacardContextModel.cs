namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.Context
{
    public class PictureSecuencePlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel[] Images { get; set; }

        public int PicturePresentationSecounds { get; set; }

        public System.Guid PictureTransitionId { get; set; }
    }
}
