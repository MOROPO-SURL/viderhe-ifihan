using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators
{
    public class FormatFormFieldValidator : IFormFieldValidator
    {
        private const string MESSAGE = "El valor especificado no está en el formato correcto.";

        public string Format { get; set; }

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return System.Text.RegularExpressions.Regex.Match(bindable.GetValue(targetBindableProperty) as string, Format, System.Text.RegularExpressions.RegexOptions.Singleline).Success ? null : MESSAGE;
        }
    }
}
