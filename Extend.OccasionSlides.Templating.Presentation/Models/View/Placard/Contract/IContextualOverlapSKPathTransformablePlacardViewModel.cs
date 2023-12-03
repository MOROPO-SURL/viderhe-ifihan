using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard.Contract
{
    public interface IContextualOverlapSKPathTransformablePlacardViewModel
    {
        OverlapShapeKind OverlapShapeKind { get; set; }

        OverlapSize OverlapSize { get; set; }

        OverlapAlignment OverlapAlignment { get; set; }
    }
}
