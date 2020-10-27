namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.View
{
    public class ActionViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public string IconGlyph { get; set; }

        public string Caption { get; set; }

        public Enumerations.ActionKind Kind { get; set; }
    }
}
