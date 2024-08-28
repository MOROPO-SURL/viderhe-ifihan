namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Pages.Detail
{
	public partial class TelevisionChannelGridAllDetailPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
	{
		public TelevisionChannelGridAllDetailPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            System.Threading.Tasks.Task.Run(() => 
            {
                System.Threading.Thread.Sleep(1000);
            }).ContinueWith(task => Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                ChannelGridView.ItemsSource = Providers.TelevisionChannelProvider.Instance.Channels;
            }));
        }

        private void ChannelGridView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (ChannelGridView.SelectedItem != null) 
            {
                System.Threading.Tasks.Task.Delay(200).ContinueWith(task => Xamarin.Forms.Device.BeginInvokeOnMainThread(() => (Parent as TelevisionChannelGridPage).HandlePickedChannel(ChannelGridView.SelectedItem as HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel)));
            }
        }
    }
}