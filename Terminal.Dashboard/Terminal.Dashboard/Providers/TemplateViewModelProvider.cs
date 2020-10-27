using SmartSolucionesCuba.Videre.Support.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Providers
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

        public System.Collections.Generic.List<Support.Presentation.Models.View.TemplateViewModel> Models { get; private set; }

        private TemplateViewModelProvider()
        {
            Models = new System.Collections.Generic.List<Support.Presentation.Models.View.TemplateViewModel>();

            Models.AddRange(Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors().Select(d => d.ToViewModel()));
        }
    }
}
