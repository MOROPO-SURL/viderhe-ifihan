namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Models.View
{
    public abstract class AbstractPlacardViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public bool RequireUnobstructedPresetation { get; set; }

        public Cloud.Persistence.Enumerations.PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }
    }
}
