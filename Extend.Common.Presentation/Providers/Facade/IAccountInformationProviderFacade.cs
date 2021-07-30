namespace SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Providers.Facade
{
    public interface IAccountInformationProviderFacade
    {
        System.Guid Id { get; }

        string Name { get; }

        Xamarin.Forms.ImageSource LogoImageSource { get; }

        Xamarin.Forms.ImageSource HorizontalSplashImageSource { get; }

        Xamarin.Forms.ImageSource VerticalSplashImageSource { get; }

        Xamarin.Forms.Color PrimaryColor { get; }

        Xamarin.Forms.Color SecoundaryColor { get; }

        System.Guid? AccountDefaultOverlayId { get; }

        string AccountSerializedOverlayContext { get; }
    }
}
