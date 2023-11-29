using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class ConfigureTextPageModelFactory
    {
        public static Models.Page.ConfigureTextPageModel Build(TextViewModel target)
        {
            var result = new Models.Page.ConfigureTextPageModel();

            if (target == null) return result;

            result.Id = target.Id;
            result.About = target.About;
            result.Content = target.Content;

            return result;
        }
    }
}
