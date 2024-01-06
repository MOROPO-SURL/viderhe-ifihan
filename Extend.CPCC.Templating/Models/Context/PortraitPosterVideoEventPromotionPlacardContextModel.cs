namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Models.Context
{
    public class PortraitPosterVideoEventPromotionPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel Poster { get; set; }

        public Common.Templating.Models.Context.VideoContextModel Video { get; set; }
    }
}
