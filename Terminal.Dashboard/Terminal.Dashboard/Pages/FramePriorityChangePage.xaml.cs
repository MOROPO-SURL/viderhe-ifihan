using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class FramePriorityChangePage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.FramePriorityChangePageModel>
    {
        private System.Action successCallbackAction;

        public FramePriorityChangePage(Support.Presentation.Models.View.FrameViewModel[] frames, Support.Presentation.Models.View.FrameViewModel target, System.Action successCallbackAction)
            : base(Factories.FramePriorityChangePageModelFactory.Build(frames, target))
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

            var pick = OrderingFrameCollectionView.SelectedItem as Support.Presentation.Models.View.FrameViewModel;

            var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(Managers.SessionManager.Instance);

            client.OrderAsync(BindingContextPageModel.Target.Id, pick.Priority).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null && !task.IsCanceled)
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Prioridad del marco aumentada con exito.");

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

            if ((OrderingFrameCollectionView.SelectedItem as Support.Presentation.Models.View.FrameViewModel).Placard == null) return;

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