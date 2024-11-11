namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Providers
{
    public class EmbeddedFontFamilyNamesProvider : Common.Templating.Presentation.Providers.Facade.IEmbeddedFontFamilyNamesProviderFacade
    {
        public string[] GetAll()
        {
            return new string[]
            {
                "DIN Pro (Black)",
                "DIN Pro (Black Italic)",
                "DIN Pro (Bold)",
                "DIN Pro (Bold Italic)",
                "DIN Pro (Condensed Black)",
                "DIN Pro (Condensed Black Italic)",
                "DIN Pro (Condensed Bold)",
                "DIN Pro (Condensed Bold Italic)",
                "DIN Pro (Condensed Italic)",
                "DIN Pro (Condensed Light)",
                "DIN Pro (Condensed Light Italic)",
                "DIN Pro (Condensed Medium)",
                "DIN Pro (Condensed Regular)",
                "DIN Pro (Italic)",
                "DIN Pro (Light)",
                "DIN Pro (Light Italic)",
                "DIN Pro (Medium)",
                "DIN Pro (Medium Italic)",
                "DIN Pro (Regular)"
            };
        }
    }
}