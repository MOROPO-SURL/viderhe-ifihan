using MOROPO.VIDERHE.Extend.Common.Templating.Descriptors;
using MOROPO.VIDERHE.Support.Extend.Templating.Providers;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Providers;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class TemplatePickPage : XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action completedCallbackAction;

        public TemplatePickPage(System.Action completedCallbackAction)
        {
            InitializeComponent();

            this.completedCallbackAction = completedCallbackAction;

            BindingContext = TemplateViewModelProvider.Instance.GetViewModels();
        }

        private void TemplateOverviewSelectButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var model = ((sender as Xamarin.Forms.BindableObject).BindingContext as TemplateViewModel);

            ITemplateDescriptor descriptor = null;

            descriptor = TemplateDescriptorProvider.Instance.GetDescriptorById(model.Id);

            if (descriptor == null)
            {
                DisplayAlert("Error", "Plantilla no compatible con la versión actual del sistema.", "Aceptar");

                return;
            }

            var createPlacardEntryPointPage = Providers.PlacardConfigurationPageProvider.Instance.GetCreationEntryPointPageByDescriptor(descriptor, DelegationCompleted);

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