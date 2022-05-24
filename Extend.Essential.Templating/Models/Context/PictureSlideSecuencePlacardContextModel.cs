namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Models.Context
{
    public class PictureSlideSecuencePlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public PictureSlideContextModel[] Slides { get; set; }

        public int PicturePresentationSecounds { get; set; }

        public System.Guid PictureTransitionId { get; set; }
    }
}
