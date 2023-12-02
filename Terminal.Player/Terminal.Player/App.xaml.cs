using MOROPO.VIDERHE.Support.Presentation.Helpers;
using MOROPO.VIDERHE.Support.Presentation.Managers;
using MOROPO.VIDERHE.Support.Presentation.Providers.Facade;
using MOROPO.VIDERHE.Terminal.Player.Managers;
using MOROPO.VIDERHE.Terminal.Player.Providers;

namespace MOROPO.VIDERHE.Terminal.Player
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.DependencyService.Register<Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade, AccountInformationProvider>();
            Xamarin.Forms.DependencyService.RegisterSingleton<ICloudServerProviderFacade>(SessionMemoryManager.Instance);
            Xamarin.Forms.DependencyService.RegisterSingleton<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>(SessionManager.Instance);

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
