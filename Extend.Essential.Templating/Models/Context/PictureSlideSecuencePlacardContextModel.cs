using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public class PictureSlideSecuencePlacardContextModel : AbstractPlacardContextModel
    {
        public PictureSlideContextModel[] Slides { get; set; }

        public int PicturePresentationSecounds { get; set; }

        public System.Guid PictureTransitionId { get; set; }
    }
}
