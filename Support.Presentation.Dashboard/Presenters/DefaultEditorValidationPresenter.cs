namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Presenters
{
    public sealed class DefaultEditorValidationPresenter : Contract.IFormFieldValidationPresenter
    {
        private static DefaultEditorValidationPresenter instance;

        public static DefaultEditorValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultEditorValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            var editor = view as Xamarin.Forms.Editor;

            editor.BackgroundColor = Xamarin.Forms.Color.Tomato;
            editor.TextColor = Xamarin.Forms.Color.DarkRed;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            var entry = view as Xamarin.Forms.Editor;

            entry.BackgroundColor = Xamarin.Forms.Color.White;
            entry.TextColor = Xamarin.Forms.Color.Black;
        }
    }
}
