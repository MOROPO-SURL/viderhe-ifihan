namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class FormPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool isValid;

        public FormPageModel()
        {
            IsValid = true;

            ValidationMessages = new System.Collections.ObjectModel.ObservableCollection<View.ValidationMessageViewModel>();
        }

        public bool IsValid { get => isValid; set => SetProperty(ref isValid, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.ValidationMessageViewModel> ValidationMessages { get; private set; }

        public void ResetValidationState()
        {
            IsValid = true;

            ValidationMessages.Clear();
        }
    }
}
