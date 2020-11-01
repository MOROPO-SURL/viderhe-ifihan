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

        public Support.Presentation.Models.View.TemplateViewModel[] GetViewModels(Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind playerOrientationSupportKind)
        {
            return Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors().Select(d => d.ToViewModel(playerOrientationSupportKind)).ToArray();
        }
    }
}
