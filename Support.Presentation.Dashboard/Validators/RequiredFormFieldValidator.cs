namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators
{
    public class RequiredFormFieldValidator : Contract.IFormFieldValidator
    {
        private const string MESSAGE = "Este campo es requerido.";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return !string.IsNullOrWhiteSpace(bindable.GetValue(targetBindableProperty) as string) ? null : MESSAGE;
        }
    }
}
