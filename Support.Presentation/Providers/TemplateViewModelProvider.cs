using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Presentation.Providers
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

        public TemplateViewModel[] GetViewModels()
        {
            return Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors().Select(d => d.ToViewModel()).ToArray();
        }
    }
}
