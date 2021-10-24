namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages.Contract
{
    public interface IValidableFormPage
    {
        void AddValidationBehavior(Behaviors.Contract.IFormFieldValidationBehavior validationBehavior);

        void RemoveValidationBehavior(Behaviors.Contract.IFormFieldValidationBehavior validationBehavior);

        void PresentAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message);

        void PresentAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label);
    }
}
