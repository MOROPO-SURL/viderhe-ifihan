using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters
{
    public sealed class DefaultDatePickerValidationPresenter : IFormFieldValidationPresenter
    {
        private static DefaultDatePickerValidationPresenter instance;

        public static DefaultDatePickerValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultDatePickerValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            var editor = view as Xamarin.Forms.DatePicker;

            editor.BackgroundColor = Xamarin.Forms.Color.Tomato;
            editor.TextColor = Xamarin.Forms.Color.DarkRed;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            var entry = view as Xamarin.Forms.DatePicker;

            entry.BackgroundColor = Xamarin.Forms.Color.White;
            entry.TextColor = Xamarin.Forms.Color.Black;
        }
    }
}
