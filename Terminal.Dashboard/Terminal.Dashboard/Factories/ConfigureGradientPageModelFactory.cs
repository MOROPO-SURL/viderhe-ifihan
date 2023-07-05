namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class ConfigureGradientPageModelFactory
    {
        public static Models.Page.ConfigureGradientPageModel Build(Support.Presentation.Dashboard.Models.View.GradientViewModel target)
        {
            var result = new Models.Page.ConfigureGradientPageModel();

            if (target == null) return result;

            result.Id = target.Id;
            result.About = target.About;
            result.Data = target.Source.Stylesheet;

            return result;
        }
    }
}
