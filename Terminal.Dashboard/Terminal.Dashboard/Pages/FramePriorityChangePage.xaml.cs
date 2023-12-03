using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Terminal.Dashboard.Factories;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class FramePriorityChangePage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<FramePriorityChangePageModel>
    {
        private System.Action successCallbackAction;

        public FramePriorityChangePage(FrameViewModel[] frames, FrameViewModel target, System.Action successCallbackAction)
            : base(FramePriorityChangePageModelFactory.Build(frames, target))
        {
            this.successCallbackAction = successCallbackAction;

            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            CancelButton_Clicked(this, System.EventArgs.Empty);

            return true;
        }

        private void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.IsBusy = true;

            var pick = OrderingFrameCollectionView.SelectedItem as FrameViewModel;

            var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(SessionManager.Instance);

            client.OrderAsync(BindingContextPageModel.Target.Id, pick.Priority).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null && !task.IsCanceled)
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Prioridad del cartel aumentada con exito.");

                        successCallbackAction.Invoke();

                        successCallbackAction = null;

                        this.NavigationPopModalPageAsync();
                    }
                });
            });
        }

        private void CancelButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            successCallbackAction = null;

            this.NavigationPopModalPageAsync();
        }

        private void OrderingFrameCollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.CurrentSelection.Count <= 0) return;

            if ((OrderingFrameCollectionView.SelectedItem as FrameViewModel).Placard == null) return;

            System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    OrderingFrameCollectionView.SelectedItem = null;
                });
            });
        }
    }
}