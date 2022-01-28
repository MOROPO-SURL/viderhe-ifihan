namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPlacardConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private bool requireUnobstructedPresetation;
        private Enumerations.ConfigurationPlayerOrientationSupportKind playerOrientationSupportKind;

        public AbstractPlacardConfigurationPageModel()
        {
            AvailableConfigurationPlayerOrientationSupportKinds = new[] { Enumerations.ConfigurationPlayerOrientationSupportKind.Inherited, Enumerations.ConfigurationPlayerOrientationSupportKind.Landscape, Enumerations.ConfigurationPlayerOrientationSupportKind.Portrait };
        }

        public bool RequireUnobstructedPresetation { get => requireUnobstructedPresetation; set => SetProperty(ref requireUnobstructedPresetation, value); }


        public Enumerations.ConfigurationPlayerOrientationSupportKind PlayerOrientationSupportKind { get => playerOrientationSupportKind; set => SetProperty(ref playerOrientationSupportKind, value); }

        public Enumerations.ConfigurationPlayerOrientationSupportKind[] AvailableConfigurationPlayerOrientationSupportKinds { get; private set; }
    }
}
