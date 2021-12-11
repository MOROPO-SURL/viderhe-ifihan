namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Validators.Contract
{
    public interface IFormFieldValidator
    {
        string Validate(Xamarin.Forms.BindableObject bindable, Xamarin.Forms.BindableProperty targetBindableProperty);
    }
}
