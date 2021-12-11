namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Presenters
{
    public class DefaultCollectionFlexLayoutValidationPresenter : Contract.IFormFieldValidationPresenter
    {
        private static DefaultCollectionFlexLayoutValidationPresenter instance;

        public static DefaultCollectionFlexLayoutValidationPresenter Instance
        {
            get
            {
                if (instance == null) instance = new DefaultCollectionFlexLayoutValidationPresenter();

                return instance;
            }
        }

        public void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            (view.Parent as Xamarin.Forms.View).BackgroundColor = Xamarin.Forms.Color.Tomato;
        }

        public void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            (view.Parent as Xamarin.Forms.View).BackgroundColor = Xamarin.Forms.Color.DimGray;
        }
    }
}
