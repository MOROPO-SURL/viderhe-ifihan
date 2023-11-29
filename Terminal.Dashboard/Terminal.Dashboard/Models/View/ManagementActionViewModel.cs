using MOROPO.VIDERHE.Extend.Common.Management.Sections.Contract;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.View
{
    public class ManagementActionViewModel : ActionViewModel
    {
        public IManagementSection Section { get; set; }

        public new string Caption { get => Section.Name ; private set => throw new System.InvalidOperationException(); }

        public new string IconGlyph { get => Section.IconGlyph; private set => throw new System.InvalidOperationException(); }

        public new Enumerations.ActionKind Kind { get; set; }

        private ManagementActionViewModel()
        {
            throw new System.InvalidOperationException();
        }

        public ManagementActionViewModel(IManagementSection section)
        {
            Section = section;
            Kind = Enumerations.ActionKind.ManagementSection;
            Enabled = true;
        }        
    }
}
