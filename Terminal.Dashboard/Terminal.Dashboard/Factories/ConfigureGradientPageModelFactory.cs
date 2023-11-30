using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class ConfigureGradientPageModelFactory
    {
        public static ConfigureGradientPageModel Build(GradientViewModel target)
        {
            var result = new ConfigureGradientPageModel();

            if (target == null) return result;

            result.Id = target.Id;
            result.About = target.About;
            result.Data = target.Source.Stylesheet;

            return result;
        }
    }
}
