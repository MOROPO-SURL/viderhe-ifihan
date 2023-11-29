using MOROPO.VIDERHE.Support.Presentation.Helpers;
using MOROPO.VIDERHE.Support.Presentation.Managers;
using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.DependencyService.Register<Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade, Providers.AccountInformationProvider>();
            Xamarin.Forms.DependencyService.RegisterSingleton<ICloudServerProviderFacade>(SessionMemoryManager.Instance);
            Xamarin.Forms.DependencyService.RegisterSingleton<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>(Managers.SessionManager.Instance);

            ImageUriFactoryHelper.Instance.Initialize();

            MainPage = new Pages.StartingPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
