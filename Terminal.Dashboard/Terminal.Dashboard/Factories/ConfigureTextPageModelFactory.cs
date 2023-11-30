using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class ConfigureTextPageModelFactory
    {
        public static ConfigureTextPageModel Build(TextViewModel target)
        {
            var result = new ConfigureTextPageModel();

            if (target == null) return result;

            result.Id = target.Id;
            result.About = target.About;
            result.Content = target.Content;

            return result;
        }
    }
}
