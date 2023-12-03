using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Models.View
{
    public abstract class AbstractPlacardViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public bool RequireUnobstructedPresetation { get; set; }

        public PlacardComplementationKind? ComplementationKind { get; set; }

        public string SerializedComplementation { get; set; }
    }
}
