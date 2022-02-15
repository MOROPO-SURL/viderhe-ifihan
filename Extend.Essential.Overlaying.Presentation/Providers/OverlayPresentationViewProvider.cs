namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.SimpleHighlightsOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.SimpleHighlightsContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.SimpleHighlightsOverlayView(new Models.View.SimpleHighlightsViewModel
                {
                    Header = context.Header,
                    Highlights = context.Highlights
                });
            }

            return null;
        }
    }
}
