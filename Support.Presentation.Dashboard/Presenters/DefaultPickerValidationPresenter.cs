namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters
{
    public sealed class DefaultPickerValidationPresenter : Contract.IFormFieldValidationPresenter
    {
        private static DefaultPickerValidationPresenter instance;

        public static DefaultPickerValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultPickerValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            var picker = view as Xamarin.Forms.Picker;

            picker.BackgroundColor = Xamarin.Forms.Color.Tomato;
            picker.TextColor = Xamarin.Forms.Color.DarkRed;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            var picker = view as Xamarin.Forms.Picker;

            picker.BackgroundColor = Xamarin.Forms.Color.White;
            picker.TextColor = Xamarin.Forms.Color.Black;
        }
    }
}
