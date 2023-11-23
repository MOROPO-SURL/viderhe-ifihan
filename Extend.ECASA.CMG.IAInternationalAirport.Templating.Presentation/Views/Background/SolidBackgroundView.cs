namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Background
{
    public class SolidBackgroundView : Xamarin.Forms.BoxView
    {
        public SolidBackgroundView(Models.View.Background.SolidBackgroundViewModel model)
        {
            Color = model.Color;
        }
    }
}
