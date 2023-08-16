namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Validators
{
    public class DateComparisonFormFieldValidator : Contract.IFormFieldValidator
    {
        public Xamarin.Forms.DatePicker ReferenceField { get; set; }

        public Xamarin.Forms.Label ReferenceFieldLabel { get; set; }

        public Xamarin.Forms.Switch FieldValidationSwich { get; set; }

        public bool IsIqualAllowed { get; set; } = false;

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            var value = bindable.GetValue(targetBindableProperty);

            if (FieldValidationSwich != null && !FieldValidationSwich.IsToggled) return null;

            if (!ReferenceField.IsEnabled) return null;

            if (IsIqualAllowed)
            {
                return ReferenceField.Date <= ((System.DateTime)value).Date ? null : string.Format("Esta fecha no debe ser menor que la especificada en el campo {0}", ReferenceFieldLabel.Text);
            }

            return ReferenceField.Date < ((System.DateTime)value).Date ? null : string.Format("Esta fecha no debe ser menor o igual que la especificada en el campo {0}", ReferenceFieldLabel.Text);
        }
    }
}
