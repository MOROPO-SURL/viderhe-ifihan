namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Providers
{
    public sealed class EmbeddedFontFamilyNamesProvider : Common.Templating.Presentation.Providers.Facade.IEmbeddedFontFamilyNamesProviderFacade
    {
        public string[] GetAll()
        {
            return new string[] 
            { 
                "Permanent Marker (Regular)",
                "Euphoria Script (Regular)",
                "Crete Round (Regular)",
                "Crete Round (Italic)",
                "Expletus Sans (Bold)",
                "Expletus Sans (Semi Bold)",
                "Expletus Sans (Medium)"
            };
        }
    }
}
