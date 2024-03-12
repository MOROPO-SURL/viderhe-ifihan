using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Models.Context
{
    public class SimplePicturePlacardContextModel : AbstractScreenTimedPlacardContextModel
    {
        public SimplePicturePlacardContextModel()
        {
            IsZoomingEnabled = false;
        }

        public ImageContextModel Image { get; set; }

        public PictureLayoutMode LayoutMode { get; set; }

        public bool IsZoomingEnabled { get; set; }
    }
}
