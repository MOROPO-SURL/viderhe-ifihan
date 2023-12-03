using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract
{
    public interface IValidableFormPage
    {
        void AddValidationBehavior(IFormFieldValidationBehavior validationBehavior);

        void RemoveValidationBehavior(IFormFieldValidationBehavior validationBehavior);

        void AddValidationMessage(string label, string message);
    }
}
