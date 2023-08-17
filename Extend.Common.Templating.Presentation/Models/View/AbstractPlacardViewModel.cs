namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Models.View
{
    public abstract class AbstractPlacardViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public double Scale { get; set; } = 1.0d;

        public bool RequireUnobstructedPresetation { get; set; }

        public Cloud.Persistence.Enumerations.PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }
    }
}
