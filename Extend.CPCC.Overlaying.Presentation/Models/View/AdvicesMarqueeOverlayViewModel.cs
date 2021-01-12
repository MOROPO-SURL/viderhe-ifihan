namespace SmartSolucionesCuba.Videre.Extend.CPCC.Overlaying.Presentation.Models.View
{
    public class AdvicesMarqueeOverlayViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string inLineAdvices;

        public string InLineAdvices { get => inLineAdvices; set => SetProperty(ref inLineAdvices, value); }
    }
}
