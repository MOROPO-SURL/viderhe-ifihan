namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages.Contract
{
    public interface IValidableFormPage
    {
        void AddValidationBehavior(Behaviors.Contract.IFormFieldValidationBehavior validationBehavior);

        void RemoveValidationBehavior(Behaviors.Contract.IFormFieldValidationBehavior validationBehavior);
        
        void AddValidationMessage(string label, string message);
    }
}
