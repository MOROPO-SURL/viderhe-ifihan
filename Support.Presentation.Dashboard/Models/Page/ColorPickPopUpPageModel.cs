using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    internal class ColorPickPopUpPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private Xamarin.Forms.Color inColor;
        private Xamarin.Forms.Color outColor;

        public ColorPickPopUpPageModel()
        {
            Recents = new ObservableCollection<Xamarin.Forms.Color>();
        }

        public Xamarin.Forms.Color InColor { get => inColor; set => SetProperty(ref inColor, value); }

        public Xamarin.Forms.Color OutColor { get => outColor; set => SetProperty(ref outColor, value); }

        public ObservableCollection<Xamarin.Forms.Color> Recents { get; private set; }
    }
}
