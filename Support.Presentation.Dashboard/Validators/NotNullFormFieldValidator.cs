using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators
{
    public class NotNullFormFieldValidator : IFormFieldValidator
    {
        private const string MESSAGE = "Este campo es requerido.";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return bindable.GetValue(targetBindableProperty) != null ? null : MESSAGE;
        }
    }
}
