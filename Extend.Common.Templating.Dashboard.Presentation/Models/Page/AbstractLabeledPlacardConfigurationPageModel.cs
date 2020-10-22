namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractLabeledPlacardConfigurationPageModel : AbstractPlacardConfigurationPageModel
    {
        private string label;

        public string Label
        {
            get => label;
            set => SetProperty(ref label, value);
        }
    }
}
