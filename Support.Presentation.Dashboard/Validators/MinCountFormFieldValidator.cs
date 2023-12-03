namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators
{
    public class MinCountFormFieldValidator : Contract.IFormFieldValidator
    {
        private const string MESSAGE_TEMPLATE = "El listado debe tener {0} o más elementos.";

        public int MinCount { get; set; }

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            return (bindable.GetValue(targetBindableProperty) as System.Collections.ICollection).Count >= MinCount ? null : string.Format(MESSAGE_TEMPLATE, MinCount);
        }
    }
}
