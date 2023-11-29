using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Validators
{
    public class OverlayFormFieldValidator : IFormFieldValidator
    {
        public Pages.Contract.IOverlayContextConfigurationPage ConfigurationPage { get; set; }

        private const string MESSAGE = "La configuración de la carátula es requerida.";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            var entry = bindable as Xamarin.Forms.Picker;

            if (entry.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(ConfigurationPage.GetCurrentSerializedOverlayContext())) return MESSAGE;
            }

            return null;
        }
    }
}
