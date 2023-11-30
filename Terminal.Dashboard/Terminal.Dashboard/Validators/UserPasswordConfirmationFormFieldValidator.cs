using MOROPO.VIDERHE.Support.Presentation.Dashboard.Validators.Contract;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Validators
{
    public class UserPasswordConfirmationFormFieldValidator : IFormFieldValidator
    {
        private const string REQUIRED_MESSAGE = "Este campo es requerido.";

        private const string MISMATCH_MESSAGE = "El valor especificado no coicide con el del campo Nueva Contraseña.";

        public string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty)
        {
            var entry = bindable as Xamarin.Forms.Entry;

            if (entry.IsEnabled)
            {
                if (string.IsNullOrEmpty(entry.Text)) return REQUIRED_MESSAGE;

                string newPassword = null;

                if (bindable.BindingContext is Models.Page.EditUserProfilePageModel)
                {
                    newPassword = (bindable.BindingContext as Models.Page.EditUserProfilePageModel).TargetUserNewPassword;
                }
                else if (bindable.BindingContext is Models.Page.ConfigureModeratorPageModel)
                {
                    newPassword = (bindable.BindingContext as Models.Page.ConfigureModeratorPageModel).TargetUserNewPassword;
                }

                if (entry.Text != newPassword) return MISMATCH_MESSAGE;
            }

            return null;
        }
    }
}
