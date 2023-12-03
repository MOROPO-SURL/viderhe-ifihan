namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Background
{
    public class GradientBackgroundView : MagicGradients.GradientView
    {
        public GradientBackgroundView(Models.View.Background.GradientBackgroundViewModel model)
        {
            GradientSource = model.Source;
        }
    }
}
