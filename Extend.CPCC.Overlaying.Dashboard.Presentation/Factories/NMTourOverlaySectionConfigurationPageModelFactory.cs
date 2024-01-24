using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories
{
    public static class NMTourOverlaySectionConfigurationPageModelFactory
    {
        public static Models.Page.NMTourOverlaySectionConfigurationPageModel Build(NMTourOverlaySectionContextModel model)
        {
            return new Models.Page.NMTourOverlaySectionConfigurationPageModel
            {
                Glyph = model?.Glyph,
                Title = model?.Title,
                Action = model?.Action
            };
        }
    }
}
