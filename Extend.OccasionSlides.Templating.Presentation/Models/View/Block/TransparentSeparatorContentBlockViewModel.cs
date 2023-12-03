using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class TransparentSeparatorContentBlockViewModel : AbstractContentBlockViewModel
    {
        private SeparatorSizingMode sizingMode;

        public SeparatorSizingMode SizingMode { get => sizingMode; set => SetProperty(ref sizingMode, value); }
    }
}
