using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class ManageExtensionsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageExtensionsPageModel>
    {
        public ManageExtensionsPage() : base(new Models.Page.ManageExtensionsPageModel { IsBusy = true })
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadExtensions();

            IsEnabled = true;
        }

        private void LoadExtensions()
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1));

                return Managers.SessionManager.Instance.AccountExtensions.Select(p => new Models.View.ExtensionViewModel
                {
                    Descriptor = Support.Extend.Providers.ExtensionDescriptorProvider.Instance.GetDescriptorById(p.Id),
                    Enabled = p.Enabled,
                    TemplateDescriptors = p.Templates.Select(t => Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray(),
                    TransitionDescriptors = p.Transitions.Select(t => Support.Extend.Motion.Providers.TransitionDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray(),
                    OverlayDescriptors = p.Overlays.Select(t => Support.Extend.Overlaying.Providers.OverlayDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray()
                }).ToArray();
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var item in task.Result)
                        {
                            BindingContextPageModel.Items.Add(item);
                        }
                    }
                });
            });
        }
    }
}