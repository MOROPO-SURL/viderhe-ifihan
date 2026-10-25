using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages.Master
{
    public partial class SettingsMasterPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<SettingsMasterPageModel>
    {
        public SettingsMasterPage() : base(new Models.Page.SettingsMasterPageModel())
        {
            InitializeComponent();
        }

        private void SectionListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs eventArgs)
        {
            //if ((Parent as Xamarin.Forms.MasterDetailPage).Detail is Xamarin.Forms.NavigationPage)
            //{
            //    ((Parent as Xamarin.Forms.MasterDetailPage).Detail as Xamarin.Forms.NavigationPage).PopToRootAsync(false);
            //}

            //var outgoingPage = (Parent as Xamarin.Forms.MasterDetailPage).Detail;

            //var incomingNavigationPage = new Xamarin.Forms.NavigationPage((e.SelectedItem as Models.NavigationSectionModel).SelectionFunc.Invoke());

            //(Parent as Xamarin.Forms.MasterDetailPage).Detail = incomingNavigationPage;

            //if (outgoingPage is System.IDisposable)
            //{
            //    (outgoingPage as System.IDisposable).Dispose();
            //}

            //System.Threading.Tasks.Task.Delay(System.TimeSpan.FromMilliseconds(100)).ContinueWith(task =>
            //{
            //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            //    {
            //        (Parent as Xamarin.Forms.MasterDetailPage).IsPresented = false;
            //    });
            //});
        }

        private void GoHomeToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}