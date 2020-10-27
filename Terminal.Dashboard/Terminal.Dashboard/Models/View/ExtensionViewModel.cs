namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.View
{
    public class ExtensionViewModel
    {
        public Extend.Common.Descriptors.IExtensionDescriptor Descriptor { get; set; }

        public bool Enabled { get; set; }

        public Extend.Common.Templating.Descriptors.ITemplateDescriptor[] TemplateDescriptors { get; set; }

        public Extend.Common.Motion.Descriptors.ITransitionDescriptor[] TransitionDescriptors { get; set; }

        public Extend.Common.Overlaying.Descriptors.IOverlayDescriptor[] OverlayDescriptors { get; set; }
    }
}
