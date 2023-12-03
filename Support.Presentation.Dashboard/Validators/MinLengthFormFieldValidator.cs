using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators
{
    public class MinLengthFormFieldValidator : IFormFieldValidator
    {
        private const string MESSAGE_TEMPLATE = "El valor especificado debe tener {0} o más caracteres.";

        public int MinLength { get; set; }

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return (bindable.GetValue(targetBindableProperty) as string).Length >= MinLength ? null : string.Format(MESSAGE_TEMPLATE, MinLength);
        }
    }
}
