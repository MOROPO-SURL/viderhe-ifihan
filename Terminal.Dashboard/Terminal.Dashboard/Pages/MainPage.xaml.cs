using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class MainPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.MainPageModel>
    {
        public MainPage() : base(new Models.Page.MainPageModel { IsBusy = true })
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            ReloadActions();

            BindingContextPageModel.IsBusy = false;

            IsEnabled = true;
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
            {
                if (task.Result)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Xamarin.Forms.DependencyService.Get<Managers.Facade.IApplicationManagerFacade>().Quit();
                    });
                }
            });

            return true;
        }

        private void SignOutToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Esta seguro que desea terminar la sesión?", "Cerrar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Managers.SessionManager.Instance.SignOut();

                    IsEnabled = false;

                    this.NavigationPushModalPageAsync(new UserAuthenticationPage());
                });
            });
        }

        private void ActionFrame_Tapped(object sender, System.EventArgs eventArgs)
        {
            switch (((sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ActionViewModel).Kind)
            {
                case Enumerations.ActionKind.ManageImages:
                    this.NavigationPushPageAsync(new ManageImagesPage());

                    break;

                case Enumerations.ActionKind.ManageVideos:
                    this.NavigationPushPageAsync(new ManageVideosPage());

                    break;

                case Enumerations.ActionKind.ManagePlayers:
                    this.NavigationPushPageAsync(new ManagePlayersPage());

                    break;

                case Enumerations.ActionKind.ManageScreenplays:
                    this.NavigationPushPageAsync(new ManageProgrammingPage());

                    break;

                case Enumerations.ActionKind.ConfigAccount:
                    this.NavigationPushPageAsync(new AccountIdentityConfigurationPage());

                    break;

                case Enumerations.ActionKind.ManageExtensions:
                    this.NavigationPushPageAsync(new ManageExtensionsPage());

                    break;

                default:
                    DisplayAlert("Aviso", "Sección no disponible para esta versión", "Aceptar");

                    break;
            }
        }

        private void ReloadActions()
        {
            BindingContextPageModel.Actions.Clear();

            var actions = new Models.View.ActionViewModel[]
            {
                new Models.View.SessionActionViewModel
                {
                    Kind = Enumerations.ActionKind.SessionDetail
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ConfigAccount,
                    Caption = "Cuenta",
                    IconGlyph = "\uf0d6"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageExtensions,
                    Caption = "Complementos",
                    IconGlyph = "\uF431"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageImages,
                    Caption = "Imágenes",
                    IconGlyph = "\uFC69"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageVideos,
                    Caption = "Videos",
                    IconGlyph = "\uF567"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageScreenplays,
                    Caption = "Programación",
                    IconGlyph = "\uf939"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManagePlayers,
                    Caption = "Reproductores",
                    IconGlyph = "\uf448"
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.DashboardSettings,
                    Caption = "Ajustes",
                    IconGlyph = "\uf66a"
                }
            };

            foreach (var item in actions)
            {
                BindingContextPageModel.Actions.Add(item);
            }
        }
    }
}
