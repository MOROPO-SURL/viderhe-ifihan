using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

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

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.WindowsAppsLauncherOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.WindowsAppsLauncherOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.WindowsAppsLauncherOverlayView(new Models.View.WindowsAppsLauncherOverlayViewModel
                {
                    Title = context.Title,
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize,
                    Launchs = new Models.View.WindowsAppLaunchViewModel[]
                    {
                        new Models.View.WindowsAppLaunchViewModel
                        {
                            Index = 0,
                            Title = "Oficinas generales de los ferrocarriles",
                            LocalPath = context.FirstLocalPath,
                            ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.FirstVirtualTourAppLaunchTumbnail.jpg", GetType().Assembly)
                        },
                        new Models.View.WindowsAppLaunchViewModel
                        {
                            Index = 1,
                            Title = "Antiguo Hotel Camagüey: Arquitectura del patrimonio ferroviario",
                            LocalPath = context.SecoundLocalPath,
                            ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.SecoundVirtualTourAppLaunchTumbnail.jpg", GetType().Assembly)
                        },
                        new Models.View.WindowsAppLaunchViewModel
                        {
                            Index = 2,
                            Title = "Los grandes talleres ferroviarios de Garrido",
                            LocalPath = context.ThirthLocalPath,
                            ThumbnailImageSource = Xamarin.Forms.ImageSource.FromResource("SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Presentation.Assets.Images.ThirthVirtualTourAppLaunchTumbnail.jpg", GetType().Assembly)
                        }
                    }
                });
            }

            if (accountInformationProvider.AccountDefaultOverlayId.Value == Descriptors.InformationMenuOverlayDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.InformationMenuOverlayContextModel>(accountInformationProvider.AccountSerializedOverlayContext);

                return new Views.DefaultCallToActionOverlayView((object param) => 
                {
                    Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new Xamarin.Forms.NavigationPage(new Pages.InformationMenuPage(param as Models.View.InformationMenuOverlayViewModel)));
                }, new Models.View.InformationMenuOverlayViewModel
                {
                    RailwayMuseumAboutUri = context.RailwayMuseumAboutUri,
                    RailwayMuseumOfferUri = context.RailwayMuseumOfferUri,
                    RailwayMuseumBillboardUri = context.RailwayMuseumBillboardUri,
                    OHCCAboutUri = context.OHCCAboutUri,
                    OHCCOfferUri = context.OHCCOfferUri,
                    OHCCBillboardUri = context.OHCCBillboardUri,
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize
                });
            }


            return null;
        }

        private void Callback(object param) { }
    }
}
