using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Pages.Master
{
	public partial class TelevisionChannelGridMasterPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
	{
		public TelevisionChannelGridMasterPage ()
		{
			InitializeComponent ();
		}

        private void BackButton_Clicked(object sender, System.EventArgs e)
        {
			this.NavigationPopModalPageAsync();
        }
    }
}