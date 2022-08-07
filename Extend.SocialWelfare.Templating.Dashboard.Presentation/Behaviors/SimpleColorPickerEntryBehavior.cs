namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Behaviors
{
    public class SimpleColorPickerEntryBehavior : Xamarin.Forms.Behavior<Xam.Plugin.SimpleColorPicker.ColorPickerEntry>
    {
        public Xamarin.Forms.Color PreviewBorderColor { get; set; }

        protected override void OnAttachedTo(Xam.Plugin.SimpleColorPicker.ColorPickerEntry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ColorPreviewButtonBorder = PreviewBorderColor;
        }
    }
}
