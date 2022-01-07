namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Presenters.Contract
{
    public interface IFormFieldValidationPresenter
    {
        void PresentFormFieldAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message);

        void PresentFormFieldAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label);
    }
}
