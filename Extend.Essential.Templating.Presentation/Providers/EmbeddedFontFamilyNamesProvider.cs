namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Providers
{
    public class EmbeddedFontFamilyNamesProvider : Common.Templating.Presentation.Providers.Facade.IEmbeddedFontFamilyNamesProviderFacade
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