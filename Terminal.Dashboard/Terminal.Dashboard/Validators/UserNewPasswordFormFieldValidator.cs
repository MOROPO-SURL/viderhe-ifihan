using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Validators
{
    public class UserNewPasswordFormFieldValidator : IFormFieldValidator
    {
        private const string REQUIRED_MESSAGE = "Este campo es requerido.";

        private const string UNNACCEPTABLE_MESSAGE = "El valor especificado no es aceptable, no cumple con los requisitos de seguridad (8 caracteres o más, al menos una minúscula, al menos una mayúscula, al menos un número, al menos un caracter especial:@,#,$,%,^,&,+,=).";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            var entry = bindable as Xamarin.Forms.Entry;

            if (entry.IsEnabled)
            {
                if (string.IsNullOrEmpty(entry.Text)) return REQUIRED_MESSAGE;

                if (!System.Text.RegularExpressions.Regex.Match(entry.Text, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", System.Text.RegularExpressions.RegexOptions.Singleline).Success) return UNNACCEPTABLE_MESSAGE;
            }

            return null;
        }
    }
}
