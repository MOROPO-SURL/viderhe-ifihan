namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Presenters
{
    public sealed class DefaultEntryValidationPresenter : Contract.IFormFieldValidationPresenter
    {
        private static DefaultEntryValidationPresenter instance;

        public static DefaultEntryValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultEntryValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            var entry = view as Xamarin.Forms.Entry;

            entry.BackgroundColor = Xamarin.Forms.Color.Tomato;
            entry.TextColor = Xamarin.Forms.Color.DarkRed;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            var entry = view as Xamarin.Forms.Entry;

            entry.BackgroundColor = Xamarin.Forms.Color.White;
            entry.TextColor = Xamarin.Forms.Color.Black;
        }
    }
}
