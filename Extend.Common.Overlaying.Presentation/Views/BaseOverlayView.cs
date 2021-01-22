namespace SmartSolucionesCuba.Viderhe.Extend.Common.Overlaying.Presentation.Views
{
    public class BaseOverlayView : XFToolKit.Mvvm.Views.ContentView
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
