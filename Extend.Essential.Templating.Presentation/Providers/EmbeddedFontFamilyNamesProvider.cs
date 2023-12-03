using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Providers
{
    public class EmbeddedFontFamilyNamesProvider : IEmbeddedFontFamilyNamesProviderFacade
    {
        public string[] GetAll()
        {
            return new string[]
            {
                "Montserrat (Bold)",
                "Montserrat (BoldItalic)",
                "Montserrat (ExtraLight)",
                "Montserrat (Italic)",
                "Montserrat (ExtraLightItalic)",
                "Montserrat (Regular)"
            };
        }
    }
}