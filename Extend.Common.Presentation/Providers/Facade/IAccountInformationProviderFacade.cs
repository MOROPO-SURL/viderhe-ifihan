namespace SmartSolucionesCuba.Videre.Extend.Common.Presentation.Providers.Facade
{
    public interface IAccountInformationProviderFacade
    {
        System.Guid Id { get; }

        string Name { get; }

        Xamarin.Forms.ImageSource LogoImageSource { get; }

        Xamarin.Forms.ImageSource SplashImageSource { get; }

        Xamarin.Forms.Color PrimaryColor { get; }

        Xamarin.Forms.Color SecoundaryColor { get; }
    }
}
