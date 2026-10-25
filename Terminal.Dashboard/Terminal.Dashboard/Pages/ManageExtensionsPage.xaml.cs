using MOROPO.VIDERHE.Support.Extend.Overlaying.Providers;
using MOROPO.VIDERHE.Support.Extend.Providers;
using MOROPO.VIDERHE.Support.Extend.Templating.Providers;
using MOROPO.VIDERHE.Support.Extend.Transitioning.Providers;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class ManageExtensionsPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ManageExtensionsPageModel>
    {
        public ManageExtensionsPage() : base(new ManageExtensionsPageModel { IsBusy = true })
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

                return SessionManager.Instance.AccountExtensions.Select(item => new Models.View.ExtensionViewModel
                {
                    Descriptor = ExtensionDescriptorProvider.Instance.GetDescriptorById(item.Id),
                    Enabled = item.Enabled,
                    TemplateDescriptors = item.Templates.Select(t => TemplateDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray(),
                    TransitionDescriptors = item.Transitions.Select(t => TransitionDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray(),
                    OverlayDescriptors = item.Overlays.Select(t => OverlayDescriptorProvider.Instance.GetDescriptorById(t.Id)).ToArray()
                }).ToArray();
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
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