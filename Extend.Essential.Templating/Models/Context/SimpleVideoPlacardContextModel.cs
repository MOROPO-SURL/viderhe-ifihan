using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public class SimpleVideoPlacardContextModel : AbstractPlacardContextModel
    {
        public SimpleVideoPlacardContextModel()
        {
            StrechAspectKind = Enumerations.VideoStrechAspectKind.AspectFill;
        }

        public VideoContextModel Video { get; set; }

        public Enumerations.VideoStrechAspectKind StrechAspectKind { get; set; }
    }
}