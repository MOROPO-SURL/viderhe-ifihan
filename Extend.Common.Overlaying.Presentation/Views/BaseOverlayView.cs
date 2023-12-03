namespace MOROPO.VIDERHE.Extend.Common.Overlaying.Presentation.Views
{
    public class BaseOverlayView : SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView
    {
        public virtual void ShowIn()
        {
            IsVisible = true;
        }

        public virtual void ShowOut()
        {
            IsVisible = false;
        }
    }
}
