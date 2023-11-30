using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;
using MOROPO.VIDERHE.Terminal.Dashboard.Pages.Contract;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Validators
{
    public class OverlayFormFieldValidator : IFormFieldValidator
    {
        public IOverlayContextConfigurationPage ConfigurationPage { get; set; }

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
