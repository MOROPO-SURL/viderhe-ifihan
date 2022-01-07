namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Validators
{
    public class NotNullFormFieldValidator : Contract.IFormFieldValidator
    {
        private const string MESSAGE = "Este campo es requerido.";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return bindable.GetValue(targetBindableProperty) != null ? null : MESSAGE;
        }
    }
}
