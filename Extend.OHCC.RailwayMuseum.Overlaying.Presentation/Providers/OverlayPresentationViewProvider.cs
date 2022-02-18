namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Providers
{
    public class OverlayPresentationViewProvider : Common.Overlaying.Presentation.Providers.Facade.IOverlayPresentationViewProviderFacade
    {
        public Common.Overlaying.Presentation.Views.BaseOverlayView Get()
        {
            var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.WindowsAppLauncherOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.WindowsAppLauncherOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.WindowsAppLauncherOverlayView(new Models.View.WindowsAppLauncherOverlayViewModel
                {
                    LocalPath = context.LocalPath,
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize
                });
            }

            return null;
        }
    }
}
