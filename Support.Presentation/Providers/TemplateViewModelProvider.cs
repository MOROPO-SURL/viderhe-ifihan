using SmartSolucionesCuba.Videre.Support.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Support.Presentation.Providers
{
    public sealed class TemplateViewModelProvider
    {
        private static TemplateViewModelProvider instance;

        public static TemplateViewModelProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemplateViewModelProvider();
                }

                return instance;
            }
        }

        public Models.View.TemplateViewModel[] GetViewModels()
        {
            return Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors().Select(d => d.ToViewModel()).ToArray();
        }
    }
}
