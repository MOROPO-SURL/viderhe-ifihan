namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Behaviors
{
    public class ViewValidationBehavior : Xamarin.Forms.Behavior<Xamarin.Forms.View>, Contract.IFormFieldValidationBehavior
    {
        public ViewValidationBehavior()
        {
            Validators = new System.Collections.ObjectModel.ObservableCollection<Validators.Contract.IFormFieldValidator>();
        }

        public Xamarin.Forms.View Target { get; private set; }

        public Xamarin.Forms.Label Label { get; set; }

        public Xamarin.Forms.BindableProperty TargetProperty { get; set; }

        public Pages.Contract.IValidableFormPage ValidableFormPage { get; set; }

        public Presenters.Contract.IFormFieldValidationPresenter FormFieldValidationPresenter { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Validators.Contract.IFormFieldValidator> Validators { get; private set; }

        public bool Evaluate()
        {
            foreach (var validator in Validators)
            {
                var result = validator.Validate(Target, TargetProperty);
                
                if (result != null)
                {
                    FormFieldValidationPresenter?.PresentFormFieldAsNotValid(Target, Label, result);

                    ValidableFormPage.AddValidationMessage(Label.Text, result);

                    return false;
                }
            }

            FormFieldValidationPresenter?.PresentFormFieldAsValid(Target, Label);

            return true;
        }

        protected override void OnAttachedTo(Xamarin.Forms.View target)
        {
            base.OnAttachedTo(target);

            Target = target;

            ValidableFormPage.AddValidationBehavior(this);
        }

        protected override void OnDetachingFrom(Xamarin.Forms.View target)
        {
            base.OnDetachingFrom(target);

            Target = null;

            ValidableFormPage.RemoveValidationBehavior(this);
        }
    }
}
