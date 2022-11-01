namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard.Contract
{
    public interface IContextualOverlapSKPathTransformablePlacardViewModel
    {
        Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        Enumerations.OverlapSize OverlapSize { get; set; }

        Enumerations.OverlapAlignment OverlapAlignment { get; set; }
    }
}
