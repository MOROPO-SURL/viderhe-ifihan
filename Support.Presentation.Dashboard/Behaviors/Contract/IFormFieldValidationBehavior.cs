namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Behaviors.Contract
{
    public interface IFormFieldValidationBehavior
    {
        Xamarin.Forms.View Target { get; }

        bool Evaluate();
    }
}
