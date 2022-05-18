using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class EmbeddedFontFamilyNamePickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EmbeddedFontFamilyNamePickPageModel>
    {
        private System.Action<string> embededdedFontFamilyNamePickedCallbackAction;

        public EmbeddedFontFamilyNamePickPage(System.Action<string> embededdedFontFamilyNamePickedCallbackAction)
            : base(new Models.Page.EmbeddedFontFamilyNamePickPageModel
            {
                IsBusy = true
            })
        {
            InitializeComponent();

            this.embededdedFontFamilyNamePickedCallbackAction = embededdedFontFamilyNamePickedCallbackAction;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(() =>
            {
                var embeddedFontFamilyNames = Extend.Templating.Presentation.Helpers.Provisioning.EmbeddedFontFamilyNamesProvisioningHelper.Instance.GetAll();

                foreach (var item in embeddedFontFamilyNames)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.Items.Add(item);
                    });
                }
            }).ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    IsEnabled = true;

                    BindingContextPageModel.IsBusy = false;
                });
            });            
        }

        private void ItemOverviewPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            embededdedFontFamilyNamePickedCallbackAction.Invoke((string)(sender as Xamarin.Forms.BindableObject).BindingContext);

            this.NavigationPopPageAsync();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            embededdedFontFamilyNamePickedCallbackAction = null;
        }
    }
}