using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class TemplatePickPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action completedCallbackAction;

        public TemplatePickPage(System.Action completedCallbackAction)
        {
            InitializeComponent();

            this.completedCallbackAction = completedCallbackAction;

            BindingContext = Support.Presentation.Providers.TemplateViewModelProvider.Instance.GetViewModels(Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape);
        }

        private void TemplateOverviewSelectButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var model = ((sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Models.View.TemplateViewModel);

            Extend.Common.Templating.Descriptors.ITemplateDescriptor descriptor = null;

            descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(model.Id);

            if (descriptor == null)
            {
                DisplayAlert("Error", "Plantilla no compatible con la versión actual del sistema.", "Aceptar");

                return;
            }

            var createPlacardEntryPointPage = Providers.TemplateConfigurationPageProvider.GetCreationEntryPointPageByDescriptor(descriptor, Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade, DelegationCompleted);

            this.NavigationPushPageAsync(createPlacardEntryPointPage);
        }

        private void DelegationCompleted()
        {
            this.NavigationPopPageAsync();

            completedCallbackAction.Invoke();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            completedCallbackAction = null;
        }
    }
}