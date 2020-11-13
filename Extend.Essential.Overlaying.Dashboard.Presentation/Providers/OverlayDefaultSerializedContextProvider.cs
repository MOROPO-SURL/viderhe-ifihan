namespace SmartSolucionesCuba.Videre.Extend.Essential.Overlaying.Dashboard.Presentation.Providers
{
    public sealed class OverlayDefaultSerializedContextProvider : Common.Overlaying.Dashboard.Presentation.Providers.Facade.IOverlayDefaultSerializedContextProviderFacade
    {
        public string GetOverlayDefaultSerializedContext(Common.Overlaying.Descriptors.IOverlayDescriptor descriptor, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            if (descriptor.Id == Descriptors.SimpleHighlightsOverlayDescriptor.ID)
            {
                var model = new Overlaying.Presentation.Models.Context.SimpleHighlightsContextModel
                {
                    Header = accountInformationProvider.Name,
                    Highlights = "Si información que mostrar por el momento..."
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }

            return null;
        }
    }
}
